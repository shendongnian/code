    static void Main(string[] args)
    {
        ScenarioModel model = new ScenarioModel { Version = "1.0.0" };
 
        XmlSerializer ser = null;
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add(string.Empty, string.Empty);
        Console.WriteLine("File 1\n==================");
        ser = new XmlSerializer(model.GetType());
        ser.Serialize(Console.Out, model, ns);
        Console.WriteLine("\n\nFile 2\n==================");
        XmlAttributeOverrides attrOverrides = new XmlAttributeOverrides();
        XmlAttributes attr = new XmlAttributes { XmlAttribute = new XmlAttributeAttribute("Version") };
        attrOverrides.Add(model.GetType(), "Version", attr);
        ser = new XmlSerializer(model.GetType(), attrOverrides);
        ser.Serialize(Console.Out, model, ns);
        Console.WriteLine();
        Console.ReadLine();
    }
