    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    internal class Program
    {
        private static void Main(string[] args)
        {
            var data = @"<Garage>
                           <Car id=""001"">
                            <Brand>Foo</Brand>
                            <Price>100</Price>
                           </Car>
                           <Car id=""002"">
                             <Brand>Bar</Brand>
                             <Price>130</Price>
                           </Car>
                           <Car id=""003"">
                             <Brand>Re</Brand>
                             <Price>110</Price>
                           </Car>
                         </Garage>";
    
            var xml = XElement.Parse(data);
    
            var carsInRange = xml.XPathSelectElements("/Car[Price > 100 and Price <= 120]");
    
            Console.WriteLine(carsInRange.Count());
    
            var cars = xml.Elements("Car");
            var carsInRange2 = from c in cars
                               let price = (decimal)c.Element("Price")
                               where price > 100 && price <= 120
                               select c;
    
            Console.WriteLine(carsInRange2.Count());
    
            Console.ReadKey();
        }
    }
