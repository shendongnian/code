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
                // string search = Console.ReadLine();
                var search = "BM";
                
                var results = string.IsNullOrEmpty(search) ? 
                                null :
                                myCars.FindAll(car => 
                                      car.VIN.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                                      car.Make.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                                      car.Model.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                                      car.StickerPrice.ToString().Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                                      car.Year.ToString().Contains(search, StringComparison.InvariantCultureIgnoreCase));
                
                if (results!= null && results.Count != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Cars searched with " + search);
                    results.ForEach(c => Console.Write("\n{0}\t{1}\t{2}\t{3}\t{4}", c.VIN, c.Make, c.Model, c.StickerPrice, c.Year));
                }
                else
                {
                    Console.WriteLine("\nNo Cars found.");
                }
                //Console.ReadLine();
            }
        }
        
        public static class StringExtensions
        {
            public static bool Contains(this string sourceString, string toCheck, StringComparison comparison)
            {
                return sourceString != null ? sourceString.IndexOf(toCheck, comparison) >= 0 : false;
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
