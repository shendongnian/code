    XmlSerializer serializer = new XmlSerializer(typeof(List<MyClass>));
    using(FileStream stream = File.OpenWrite("filename"))
    {
      List<MyClass> list = new List<MyClass>();
      serializer.Serialize(stream, list);
    }
    using(FileStream stream = File.OpenRead("filename"))
    {
      List<MyClass> dezerializedList = (List<MyClass>)serializer.Deserialize(stream);
    }
