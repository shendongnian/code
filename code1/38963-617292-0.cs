    class SomeObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    SomeObject[] objects = new SomeObject[]
    {
        new SomeObject { ID = 1, Name = "Hello" },
        new SomeObject { ID = 2, Name = "World" }
    };
    Dictionary<int, string> objectDictionary = objects.ToDictionary(o => o.ID, o => o.Name);
