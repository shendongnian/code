    class TestClass {
        [DefaultValue(int.MinValue)]
        public int Value { get; set; }
    }
    var ser = JsonConvert.SerializeObject(new TestClass() { Value = int.MinValue}, new JsonSerializerSettings
    {
        DefaultValueHandling = DefaultValueHandling.Ignore
    });
    // serializes to empty object {}
    Console.WriteLine(ser);
    var ser = JsonConvert.SerializeObject(new TestClass() { Value = 0}, new JsonSerializerSettings
    {
        DefaultValueHandling = DefaultValueHandling.Ignore
    });
    // serializes to {"Value" : 0}
    Console.WriteLine(ser);
