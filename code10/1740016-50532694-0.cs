    var foo = new Foo();
    foo.content = "hello";
    //foo.isActive is left undefined
    Console.WriteLine($"foo.isActive is left undefined");
    Console.WriteLine($"foo.isActive = {foo.isActive}");
    XmlSerializer serializer = new XmlSerializer(typeof(Foo));
    string file = "File.xml";
    using (StreamWriter sw = new StreamWriter(file))
    {
        serializer.Serialize(sw,foo);
    }
    bool attExists = File.ReadAllText(file).Contains("isActive");
    Console.WriteLine($"It is {attExists} that isActive exists in {file}");
    using (StreamReader sr = new StreamReader(file))
    {
        Foo test = (Foo)serializer.Deserialize(sr); 
        Console.WriteLine(test.isActive);
    }
