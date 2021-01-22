    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml;
    
    namespace LinqSample1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var xml = @"
            <items>
                <item>
                    <name>Item 1</name>
                    <price>1.00</price>
                    <quantity>3</quantity>
                </item>
                <item>
                    <name>Item 2</name>
                    <price>1.50</price>
                    <quantity>1</quantity>
                </item>
            </items>";
    
                var document = new XmlDocument();
                document.LoadXml(xml);
    
                var items = from XmlNode item in document.SelectNodes("/items/item")
                            select new
                            {
                                Name = item.SelectSingleNode("name").InnerText,
                                Price = item.SelectSingleNode("price").InnerText,
                                Quantity = item.SelectSingleNode("quantity").InnerText
                            };
    
                foreach (var item in items)
                {
                    Console.WriteLine("Item Name: {0} costs {1} and we have a quantity of {2}", item.Name, item.Price, item.Quantity);
                }
            }
        }
    }
