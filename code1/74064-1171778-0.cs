    using System;
    using System.Xml.Linq;
    using System.Linq;
    
    class Test
    {
        [STAThread]
        static void Main()
        {
            XDocument document = XDocument.Load("test.xml");
            
            var items = document.Root.Elements("Element")
                 .Select(element => new
                     { Name = element.Element("Name").Value,
                       Type = element.Element("Type").Value,
                       Color = element.Element("Color").Value })
                 .ToList();
                        
            foreach (var x in items)
            {
                Console.WriteLine(x);
            }
        }
    }
