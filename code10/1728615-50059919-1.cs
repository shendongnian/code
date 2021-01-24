    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            var directories = doc.Descendants("dir");
            
            foreach (var dir in directories)
            {
                var parts = dir
                    .AncestorsAndSelf() // All the ancestors of this element, and itself
                    .Reverse()          // Reversed (so back into document order)
                    .Select(e => e.Attribute("name").Value); // Select the name
                var path = string.Join("/", parts);
                Console.WriteLine(path);
            }
        }   
    }
