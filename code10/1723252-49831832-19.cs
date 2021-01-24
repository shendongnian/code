    class Program
    {
        static void Main(string[] args)
        {
            MyRoot root = new MyRoot();
            root.SubElements.Add(new ItemType() { Name = "Jim"});
            root.SubElements.Add(new ItemType() { Name = "Ben" });
            root.SubElements.Add(new ItemType() { Name = "Tom" });
            string xml = Serialize(root, "myNewRoot");
            Console.WriteLine(xml);
            Console.ReadKey();
        }
        static string Serialize<TElement>(RootElementBase<TElement> tElement, string rootElementName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(RootElementBase<TElement>),
                new XmlRootAttribute(rootElementName));
            StringWriter stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, tElement);
            return stringWriter.ToString();
        }
    }
