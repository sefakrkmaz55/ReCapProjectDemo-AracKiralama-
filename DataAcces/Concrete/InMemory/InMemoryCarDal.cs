using DataAcces.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAcces.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()//Const. fonk. tanımı
        {
            //Herhangi bir veritabanından gelmiş fake listeyi simüle ediyoruz
            _car = new List<Car> {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=135,ModelYear=2018,Description="1.3 Multijet Az Yakar"},
                new Car{Id=2,BrandId=2,ColorId=2,DailyPrice=250,ModelYear=2021,Description="Konfor İsteyenlerin Aracı"},
                new Car{Id=3,BrandId=3,ColorId=2,DailyPrice=1350,ModelYear=2021,Description="Sürüş Zevki Aklınızdan Çıkmayacak"},
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            //LINQ Yöntemi kullanılarak foreach ile verileri dönüp if ile kontrol durumu sağlamadan direkt istenilen veriye ulaşıp silebilcez böylece performans olarak kar durumuna geçicez
            Car carToDelete = _car.SingleOrDefault(c => c.Id == car.Id);//İstenilen elemanı bulup silmemize yarar
            _car.Remove(car);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public void Update(Car car)
        {
            //LINQ Yöntemi ile istenilen veriyi update eden fonksiyon
            Car carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
