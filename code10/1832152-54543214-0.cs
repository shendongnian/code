    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace CSharpPractice.StackOverflow
    {
        public class Manufacturer
        {
            public int Id      { get; set; }
            public string Name { get; set; } // "Toyota"
        }
    
        public class Model
        {
            public int Id             { get; set; }
            public int ManufacturerFK { get; set; }
            public string Name        { get; set; } // "Land Cruiser"
            public int Year           { get; set; }
        }
    
        public class Car
        {
            public int Id       { get; set; }
            public int ModelFK  { get; set; }
            public string Color { get; set; }
        }
    
        public class StaticCarDB
        {
            static List<Manufacturer> ManufacturerTable = new List<Manufacturer>();
            static List<Model>        ModelTable        = new List<Model>();
            static List<Car>          CarTable          = new List<Car>();
    
            static StaticCarDB()
            {
                ManufacturerTable.Add( new Manufacturer() { Id = 0, Name = "Audi" });
                ManufacturerTable.Add( new Manufacturer() { Id = 1, Name = "BMW"  });
    
                ModelTable.Add(new Model() { Id = 0, ManufacturerFK = 0, Name = "A4",   Year = 2007 });
                ModelTable.Add(new Model() { Id = 1, ManufacturerFK = 0, Name = "A6",   Year = 2006 });
                ModelTable.Add(new Model() { Id = 2, ManufacturerFK = 1, Name = "325i", Year = 1990 });
                ModelTable.Add(new Model() { Id = 3, ManufacturerFK = 1, Name = "525",  Year = 2001 });
    
                CarTable.Add(new Car() { Id = 0, ModelFK = 0, Color = "Metallic Sand Micah" });
                CarTable.Add(new Car() { Id = 1, ModelFK = 2, Color = "Black" });
                CarTable.Add(new Car() { Id = 2, ModelFK = 2, Color = "Green" });
                CarTable.Add(new Car() { Id = 3, ModelFK = 3, Color = "Black" });
            }
    
            public static IEnumerable<Tuple<Car, Model, Manufacturer>> GetAllCars()
            {
                var cars =
                    from car in CarTable
                    from model in ModelTable
                        where car.ModelFK == model.Id
                    from manufacturer in ManufacturerTable
                        where model.ManufacturerFK == manufacturer.Id
                    select new Tuple<Car, Model, Manufacturer>(car, model, manufacturer);
    
                return cars;
            }
        }
    }
