    MyClass mc = new MyClass();
    mc.MyString = "<test>Hello World</test>";
    XmlSerializer serializer = new XmlSerializer(typeof(MyClass));
    StringWriter writer = new StringWriter();
    serializer.Serialize(writer, mc);
    Console.WriteLine(writer.ToString());
