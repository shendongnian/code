    [Serializable]
    public class TestClass
    {
        public string Name { get; set; }
    }
    {
        var formatter = new DataContractSerializer(typeof(TestClass));
        using (var stream = new MemoryStream())
        {
            var instance = new TestClass { Name = "Matt" };
            formatter.WriteObject(stream, instance);
            stream.Seek(0, SeekOrigin.Begin);
            var second = (TestClass) formatter.ReadObject(stream);
            Console.WriteLine(second.Name);
        }
    }
