    static void Main(string[] args)
    {
        string jsonStr = "{\"message\": \"The request is invalid.\", \"modelState\": { \"users[0].FirstName\": [\"First name is required\", \"First name should contains at least one letter\" ],\"users[1].FirstName\": [\"First name is required\", \"First name should contains at least one letter\" ]}}";
        var obj = JsonConvert.DeserializeObject<Message>(jsonStr);
        // Output
        Console.WriteLine("message: " + obj.message);
        Console.WriteLine("modelState:");
        Console.WriteLine("users[0].FirstName: ");
        foreach (var item in obj.modelState.Obj1)
            Console.WriteLine(item);
        Console.WriteLine("users[1].FirstName: ");
        foreach (var item in obj.modelState.Obj2)
            Console.WriteLine(item);
        Console.Read();
    }
    class Message
    {
        public string message { get; set; }
        public ModelState modelState { get; set; }
    }
    class ModelState
    {
        [JsonProperty("users[0].FirstName")]
        public string[] Obj1 { get; set; }
        [JsonProperty("users[1].FirstName")]
        public string[] Obj2 { get; set; }
    }
