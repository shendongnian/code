    using System;
    using System.IO;
    using System.Xml.Serialization;
    namespace ConsoleApp2
    {
        class Program
        {
            public static void Main()
            {
                var c = new CarCollection();
                c = XCar();
                foreach (var k in c.Cars)
                {
                    Console.WriteLine(k.Make + " " + k.Model + " " + k.StockNumber);
                }
                c = null;
                Console.ReadLine();
            }
            static CarCollection XCar()
            {
                using (TextReader reader = new StreamReader(@"C:\Users\SlowLearner\source\repos\ConsoleApp2\ConsoleApp2\Class1.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(CarCollection));
                    return (CarCollection)serializer.Deserialize(reader);
                }
            }
        }
    }
