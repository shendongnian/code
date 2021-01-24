    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<Car> cars = doc.Descendants("row").Select(x => new Car() {
                   newUser = (string)x.Element("NewUsed"),
                   make = (string)x.Element("Make"),
                   model = (string)x.Element("Model"),
                   derivative = (string)x.Element("Derivative"),
                   code = (string)x.Element("MMCode"),
                   registrationNumber = (string)x.Element("RegNumber"),
                   year = (int)x.Element("Year"),
                   mileage = (decimal)x.Element("Mileage"),
                   price = (decimal)x.Element("Price"),
                   pictures = x.Element("Media").Elements().Select((y,i) => new { value = (string)y, i = i})
                      .GroupBy(y => y.i / 2)
                      .GroupBy(y => (string)y.FirstOrDefault().value, z => (string)z.Last().value)
                      .ToDictionary(y => y.Key, z => z.FirstOrDefault())
                }).ToList();
     
            }
        }
        public class Car
        {
            public string newUser { get; set; }
            public string make { get; set; }
            public string model { get; set; }
            public string derivative { get; set; }
            public string code { get; set; }
            public string registrationNumber { get; set; }
            public int year { get; set; }
            public decimal mileage { get; set; }
            public decimal price { get; set; }
            public Dictionary<string, string> pictures { get; set; }
        }
    }
