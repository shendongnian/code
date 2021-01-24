    //Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                List<Car> myCars = new List<Car>() {
                    new Car() { VIN="A1", Make = "BMW", Model= "550i", StickerPrice=55000, Year=2009},
                    new Car() { VIN="B2", Make="Toyota", Model="4Runner", StickerPrice=35000, Year=2010},
                    new Car() { VIN="C3", Make="BMW", Model = "745li", StickerPrice=75000, Year=2008},
                    new Car() { VIN="D4", Make="Ford", Model="Escape", StickerPrice=25000, Year=2008},
                    new Car() { VIN="E5", Make="BMW", Model="55i", StickerPrice=57000, Year=2010}
                };
    
                Console.WriteLine("What term would you like to search?");
                string search = Console.ReadLine();
                var results = myCars.FindAll(car => string.Equals(search, car.VIN, StringComparison.InvariantCultureIgnoreCase) ||
                                      string.Equals(search, car.Make, StringComparison.InvariantCultureIgnoreCase) ||
                                      string.Equals(search, car.Model, StringComparison.InvariantCultureIgnoreCase) ||
                                      string.Equals(search, car.StickerPrice.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
                                      string.Equals(search, car.Year.ToString(), StringComparison.InvariantCultureIgnoreCase));
                if (results.Count != 0)
                {
                    DisplayResults(results, "Cars searched with " + search);
                }
                else
                {
                    Console.WriteLine("\nNo Cars found.");
                }
                Console.ReadLine();
            }
            private static void DisplayResults(List<Car> results, string title)
            {
                Console.WriteLine();
                Console.WriteLine(title);
                foreach (Car c in results)
                {
    
                    Console.Write("\n{0}\t{1}\t{2}\t{3}\t{4}", c.VIN, c.Make, c.Model, c.Year, c.StickerPrice);
                }
                Console.WriteLine();
    
            }
        }
        
        public class Car
        {
            public string VIN { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public double StickerPrice { get; set; }
        }
    }
