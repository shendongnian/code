    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp3
    {
        public class CountryNumber
        {
            public string Country { get; set; }
            public int Number { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var data = new List<CountryNumber> {
                    new CountryNumber { Country = "England", Number = 1},
                    new CountryNumber { Country = "Germany", Number = 3},
                    new CountryNumber { Country = "Hungary", Number = 1},
                    new CountryNumber { Country = "Germany", Number = 1},
                    new CountryNumber { Country = "Sweeden", Number = 1},
                    new CountryNumber { Country = "Hungary", Number = 4},
                    new CountryNumber { Country = "French", Number = 2},
                    new CountryNumber { Country = "Hungary", Number = 1},
                    new CountryNumber { Country = "England", Number = 1},
                    new CountryNumber { Country = "England", Number = 1}
                };
    
                var groupped = data.GroupBy(d => new { Country = d.Country, Number = d.Number });
    
                foreach (var one in groupped) { 
                  Console.WriteLine($"{one.Key.Country}, {one.Key.Number}: {one.Count()}");
                }                        
            }
        }
    }
