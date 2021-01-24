    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            var xml = XDocument.Load("input.xml");
            var parts = xml.Descendants("PART").ToList();
            var models = xml.Descendants("PART").Elements("MODEL").ToList();
            
            for (int i = 0; i < parts.Count; i++)
            {
                parts[i].Attribute("no").Value = $"xs{i+1}";
            }
    
            for (int i = 0; i < models.Count; i++)
            {
                models[i].Attribute("ver").Value = $"v-{i+1}";
            }
            xml.Save("output.xml");
        }
    }
