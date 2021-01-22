    class Program
    {
        static void Main(string[] args)
        {
            var xml = new StringBuilder();
            using (var writer = 
                XmlWriter.Create(xml, 
                        new XmlWriterSettings { Indent = true, 
                          ConformanceLevel = ConformanceLevel.Auto, 
                          OmitXmlDeclaration = true }))
            {
                MyClass myClass = new MyClass { Id = 1, Name = "My Name" };
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                var xs = new XmlSerializer(typeof(MyClass), "");
                xs.Serialize(writer, myClass, ns);
            }
            Console.WriteLine(xml.ToString());
            // pause program execution to review results...
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
