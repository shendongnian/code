    static void Main(string[] args)
    {
        using (var stream = new MemoryStream())
        {
            // put it in
            var formatter = new BinaryFormatter();
            var foo = new Foo();
            formatter.Serialize(stream, foo);
            // get it out
            var foo2 = (Foo) formatter.Deserialize(stream);
        }
    }
    [Serializable]
    class Foo:ISerializable
    {
        public string data;
        #region ISerializable Members
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("data",data);
        }
        #endregion
    }
