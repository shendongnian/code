    public static Foo Deserialize(string path) {
        Foo foo;
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Foo));
        using (StreamReader textReader = new StreamReader(path)) {
            foo = (Foo)xmlSerializer.Deserialize(textReader); // this does NOT fire the OnDeserialization callbacks
        }
        return foo.GetClone();
    }
        
    public Foo GetClone() {
        using (var ms = new MemoryStream()) {
            var formatter = new BinaryFormatter();
            formatter.Serialize(ms, this);
            ms.Position = 0;
            return (Foo)formatter.Deserialize(ms); // this DOES fire the OnDeserialization callbacks
        }
    }
