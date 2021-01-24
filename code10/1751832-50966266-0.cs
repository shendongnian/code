    static void Main(string[] args)
    {
        var modelJson = "{\"Id\":1,\"Options\":[{\"Id\":2,\"Name\":\"Option 1\"}]}";
        var modelDto = Jil.JSON.Deserialize<ModelNew>(modelJson);
        Console.Read();
    }
    class ModelNew
    {
        public int Id { get; set; }
        public  Option[] Options { get; set; }
        public ModelNew() {}
    }
    class Option
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        private Option() {}
    }
