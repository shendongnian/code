    using System;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            PrintDirectories(doc, null);        
        }
        
        static void PrintDirectories(XContainer parent, string path)
        {
            foreach (XElement element in parent.Elements("dir"))
            {
                string dir = element.Attribute("name").Value;
                string fullPath = path == null ? dir : $"{path}/{dir}";
                Console.WriteLine(fullPath);
                PrintDirectories(element, fullPath);
            }
        }
    }
