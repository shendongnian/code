    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            var namesToRemove = new[]
            { 
                "titleTextColor",
                "isLightTheme",
                "showText"
            };
            XDocument doc = XDocument.Load("test.xml");
            // For all the elements directly under the document root...
            doc.Root.Elements()
                // Where the array contains the value of the "name" attribute...
                .Where(x => namesToRemove.Contains((string) x.Attribute("name")))
                // Remove them from the document
                .Remove();
            doc.Save("output.xml");
        }
    }
