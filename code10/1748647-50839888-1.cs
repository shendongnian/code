    var foo = new Foo
    {
        Bar = "test",
        List1 = new List<int> { 1, 2, 3 },
        List2 = new List<double> { 0.1, 0.2, 0.3 }
    };
    var xs = new XmlSerializer(typeof(Foo));
    var settings = new XmlWriterSettings { NewLineOnAttributes = true, Indent = true };
    using (var xmlWriter = XmlWriter.Create(Console.Out, settings))
    {
        xs.Serialize(xmlWriter, foo);
    }
    Console.WriteLine();
