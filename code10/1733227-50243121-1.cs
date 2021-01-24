    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    public class Test
    {
        public static void Main(string[] args)
        {
            XDocument someDoc = XDocument.Parse(
                @"<bananas>
                    <banana tasty='yes'></banana>
                    <banana tasty='very'></banana>
                    <banana tasty='amazing'></banana>
                    <banana tasty='mind-blowing'></banana>
                    <banana tasty='disgusting'></banana>
                  </bananas>");
            IEnumerable<XElement> bananas = someDoc.Descendants("banana");
            EatSomeBananas(bananas, 2);
        }
    
        public static void EatSomeBananas(IEnumerable<XElement> bananas, int numberOfBananas)
        {
            var bananasToEat = bananas.Take(numberOfBananas);
            Console.WriteLine("Eating some bananas"); 
            foreach (var element in bananasToEat)
            {
                var tasty = element.Attribute("tasty").Value;
                Console.WriteLine($"Tasty: {tasty}");
            }
            Console.WriteLine("Eaten the bananas");
            var remainingBananas = bananas.Skip(numberOfBananas);
            if (remainingBananas.Any())
            {
                EatSomeBananas(remainingBananas, numberOfBananas);
            }
        }
    }
