    using System;
    using System.Xml.Linq;
    using System.Linq;
    
    class Test
    {
        [STAThread]
        static void Main()
        {
            XDocument document = XDocument.Load("test.xml");
            
            var items = document.Root
                                .Elements("Element")
                                .Select(element => new {
                                    Name = (string)element.Element("Name"),
                                    Type = (string)element.Element("Type"),
                                    Color = (string)element.Element("Color")})
                                .ToList();
                        
            foreach (var x in items)
            {
                Console.WriteLine(x);
            }
        }
    }
