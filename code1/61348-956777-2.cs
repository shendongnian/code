    public class Test
    {
        static void Main()
        {
            string xml = "<Ids><id>1</id><id>2</id></Ids>";
            
            XDocument doc = XDocument.Parse(xml);
            
            var list = doc.Root.Elements("id")
                               .Select(element => element.Value)
                               .ToList();
            
            foreach (string value in list)
            {
                Console.WriteLine(value);
            }
        }
    }
