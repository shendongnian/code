    static void Main(string[] args)
    {
        string json = "[{\"_id\":\"1 - 1\",\"awid\":\"1\",\"officeid\":\"1\",\"prname\":\"ABCD\",\"prfhname\":\"Chevy\",\"Ano\":\"555\"},{ \"_id\":\"1-2\",\"awid\":\"1\",\"officeid\":\"1\",\"prname\":\"bheegi\",\"prfhname\":\"Henry\",\"Ano\":\"6555\"}]";
        var message = JsonConvert.DeserializeObject<Message[]>(json);
        // To see the output (using the for loop as you like ) use this:
        for (int i = 0; i < message.Length; i++)
        {
            Console.WriteLine("_id: " + message[i]._id);
            Console.WriteLine("awid: " + message[i].awid);
            Console.WriteLine("officeid: " + message[i].officeid);
            Console.WriteLine("prname: " + message[i].prname);
            Console.WriteLine("prfhname: " + message[i].prfhname);
            Console.WriteLine("Ano: " + message[i].Ano);
            Console.WriteLine();
        }
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
