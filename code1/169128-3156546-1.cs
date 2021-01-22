    [Serializable]
    public class TestClass2 : ISerializable
    {
        public TestClass2() { }
        protected TestClass2(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("name").ToUpper();
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", Name);
        }
        public string Name { get; set; }
    }
    {
        var formatter = new DataContractSerializer(typeof(TestClass2));
        using (var stream = new MemoryStream())
        {
            var instance = new TestClass2 { Name = "Matt" };
            formatter.WriteObject(stream, instance);
            stream.Seek(0, SeekOrigin.Begin);
            var second = (TestClass2)formatter.ReadObject(stream);
            Console.WriteLine(second.Name);
        }
    }
