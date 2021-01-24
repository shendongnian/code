    class Program
    {
        static void Main(string[] args)
        {
            MyRoot root = new MyRoot();
            root.SubElements.Add(new ItemType() { Name = "Jim"});
            root.SubElements.Add(new ItemType() { Name = "Ben" });
            root.SubElements.Add(new ItemType() { Name = "Tom" });
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(MyRoot));
            StringWriter stringWriter = new StringWriter();
    
            xmlSerializer.Serialize(stringWriter, root);
    
            Console.WriteLine(stringWriter);
    
            Console.ReadKey();
        }
    }
