    static void Main(string[] args)
    {
        string json = "[{\"_id\":\"1 - 1\",\"awid\":\"1\",\"officeid\":\"1\",\"prname\":\"ABCD\",\"prfhname\":\"Chevy\",\"Ano\":\"555\"},{ \"_id\":\"1-2\",\"awid\":\"1\",\"officeid\":\"1\",\"prname\":\"bheegi\",\"prfhname\":\"Henry\",\"Ano\":\"6555\"}]";
        var message = JsonConvert.DeserializeObject<Message[]>(json);
        Console.Read();
    }
    class Message
    {
        public string _id { get; set; }
        public string awid { get; set; }
        public string officeid { get; set; }
        public string prname { get; set; }
        public string prfhname { get; set; }
        public string Ano { get; set; }
    }
