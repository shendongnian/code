    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    public class Test
    {
        public static void Main(string[] args)
        {
            var doc = XDocument.Load("test.xml");
            // Handle each Names element separately
            foreach (var container in doc.Descendants("Names"))
            {
                // Within a names element, find all the Name elements,
                // and materialize the query. (That may not be necessary; see later.)
                var names = container.Elements("Name").ToList();
                // Skip the first name, but modify each of the rest.
                foreach (var element in names.Skip(1))
                {
                    element.Name = "ChildName";
                }
            }
            Console.WriteLine(doc);
        }
    } 
