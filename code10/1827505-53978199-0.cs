    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using System.Linq;
    
    namespace ConsoleApp31
    {
        class Program
        {
            class Item
            {
                public int quantity { get; set; }
                public double price { get; set; }
            }
            static void Main(string[] args)
            {
                var dictionary_items = new Dictionary<string, Item>();
    
                dictionary_items.Add("abc", new Item() { quantity = 1, price = 3.3 });
                dictionary_items.Add("def", new Item() { quantity = 1, price = 3.3 });
    
                XDocument xDoc = new XDocument(
                    new XStreamingElement("itemlist",
                         from it in dictionary_items
                         select new XElement("item",
                                   new XAttribute("article", it.Key),
                                   new XAttribute("quantity", it.Value.quantity),
                                   new XAttribute("price", it.Value.price)))
                    );
                Console.WriteLine(xDoc.ToString());
                Console.ReadKey();
                    
            }
        }
    }
