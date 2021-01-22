    using System;
    using System.Xml.Linq;
    using System.Xml.XPath;
    public class Program
    {
        static void Main(string[] args)
        {
            var elements = XDocument.Load("Database.xml")
                .XPathSelectElements("//Record[@Number='2']/Name");
            foreach (var item in elements)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
