    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    public class Test
    {
        public static void Main(string[] args)
        {
            var doc = XDocument.Load("test.xml");
            // Materialize the query so that change element names doesn't
            // invalidate anything.
            var names = doc.Descendants("Name").ToList();
            // Skip the first element, because we don't want to change its name
            foreach (var element in names.Skip(1))
            {
                // For everything else, change the name accordingly
                element.Name = "ChildName";
            }
            Console.WriteLine(doc);
        }
    } 
