    static void Main(string[] args)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Test));
        serializer.Serialize(Console.Out, new Test());
    }
