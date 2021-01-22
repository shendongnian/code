    static void Main(string[] args)
    {
        using (var stream = new MemoryStream())
        {
            // serialize object 
            var formatter = new BinaryFormatter();
            var foo = new Foo();
            formatter.Serialize(stream, foo);
                // get a byte array
                var bytes = new byte[stream.Length];
                for(int i=0; i<stream.Length;i++)
                {
                    bytes[i] = Convert.ToByte(stream.ReadByte());
                }
            // deserialize object
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
