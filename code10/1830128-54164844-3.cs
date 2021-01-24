    var serializerSettings = new JsonSerializerSettings
    {
        DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
        ContractResolver = resolver,
    };
    var a = new A();
    JsonConvert.PopulateObject("{}", a, serializerSettings);
    Console.WriteLine(JsonConvert.SerializeObject(a, serializerSettings));
    Assert.IsTrue(JsonConvert.SerializeObject(a, serializerSettings) == "{}");
    a.SomeArray = new int[] { 4, 6, 12 };
    Console.WriteLine(JsonConvert.SerializeObject(a, serializerSettings));
    Assert.IsTrue(JsonConvert.SerializeObject(a, serializerSettings) == "{}");
