    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                new Car(FILENAME);
            }
        }
        public class Car
        {
            public static List<Car> cars = null;
            public int id { get; set;}
            public string make { get; set;}
            public string model { get; set;}
            public int year { get; set;}
            public Car() { }
            public Car(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                cars = doc.Descendants().Where(x => x.Name.LocalName == "Car").Select(x => new Car()
                {
                    id = x.Elements().Where(y => y.Name.LocalName == "Id").Select(y => (int)y).FirstOrDefault(),
                    make = x.Elements().Where(y => y.Name.LocalName == "Make").Select(y => (string)y).FirstOrDefault(),
                    model = x.Elements().Where(y => y.Name.LocalName == "Model").Select(y => (string)y).FirstOrDefault(),
                    year = x.Elements().Where(y => y.Name.LocalName == "Year").Select(y => (int)y).FirstOrDefault(),
                }).ToList();
            }
        }
    }
