    class Program
        {
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(@"C:\Users\Nullplex6\source\repos\ConsoleApp4\ConsoleApp4\Files\XMLFile4.xml");
                XNamespace ns = doc.Root.GetDefaultNamespace();
                XNamespace xdt = "http://schemas.microsoft.com/XML-Document-Transform";
    
                var result = doc.Descendants(ns + "appSettings")
                    .Elements(ns + "add")
                             .Select(x => new Key
                             {
                                 Key1 = x.Attribute(xdt + "Transform") != null ? x.Attribute(xdt + "Transform").Value : "",
                                 Value = x.Attribute(xdt + "Locator") != null ? x.Attribute(xdt + "Locator").Value : "",
                                 Transform = x.Attribute("key") != null ? x.Attribute("key").Value : "",
                                 Locator = x.Attribute("value") != null ? x.Attribute("value").Value : "",
                             }).ToList();
    
    
                result.ForEach(x => Console.WriteLine($"Transform: {x.Transform}, \t Locator: {x.Locator}, \t Key: {x.Key1}, \t Value: {x.Value}"));
    
                Console.ReadLine();
            }
        }
 
    [Serializable]
        public class Key
        {
            public string Key1 { get; set; }
            public string Value { get; set; }
            public string Transform { get; set; }
            public string Locator { get; set; }
        }
