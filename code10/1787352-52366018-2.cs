    public class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(@"C:\Users\xxx\source\repos\ConsoleApp2\Files\XMLFile2.xml");
    
            var childs = doc.Descendants("Child")
                              .Single(c => c.Attribute("Name").Value == "transaction_type")
                              .Elements().ToList();
    
            var displayMembers = childs.Attributes("Name").Select(x => x.Value).ToList();
            var valueMembers = childs.Attributes("val").Select(x => x.Value).ToList();
        }
    }
    
