    [DataContract, Serializable]
    public class TestClass3
    {
        public int Age { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
    {
        var formatter = new DataContractSerializer(typeof(TestClass3));
        using (var stream = new MemoryStream())
        {
            var instance = new TestClass3 { Name = "Matt", Age = 26 };
            formatter.WriteObject(stream, instance);
            stream.Seek(0, SeekOrigin.Begin);
            var second = (TestClass3)formatter.ReadObject(stream);
            Console.WriteLine(second.Name);
            Console.WriteLine(second.Age);
        }
    }
