    public class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(@"C:\Users\Nullplex6\source\repos\ConsoleApp2\Files\XMLFile2.xml");
    
            var childs = doc.Descendants("Child")
                              .Single(c => c.Attribute("Name").Value == "transaction_type")
                              .Elements().ToList();
    
            var displayMembers = childs.Attributes("Name").ToList();
            var valueMembers = childs.Attributes("val").ToList();
        }
    }
    
