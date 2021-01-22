    static void Main(string[] args)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(TestClass));
        MemoryStream memoryStream = new MemoryStream();
        XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        TestClass domain = new TestClass(10, 3);
        xmlSerializer.Serialize(xmlWriter, domain);
        memoryStream = (MemoryStream)xmlWriter.BaseStream;
        string xmlSerializedString = ConvertByteArray2Str(memoryStream.ToArray());
        TestClass xmlDomain = (TestClass)DeserializeObject(xmlSerializedString);
        Console.WriteLine(xmlDomain.TestFunction().ToString());
        Console.ReadLine();
    }
