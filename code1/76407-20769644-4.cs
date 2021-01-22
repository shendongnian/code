    class Program
    {
        static void Main(string[] args)
        {
            List<User> list = new List<User>
            {
                new User { Id = 1, Username = "john.smith" },
                new User { Id = 5, Username = "steve.martin" }
            };
            JObject json = new JObject();
            json["users"] = JToken.FromObject(list);
            Console.WriteLine("First approach (" + json["users"].Type + "):");
            Console.WriteLine();
            Console.WriteLine(json.ToString(Formatting.Indented));
            Console.WriteLine();
            Console.WriteLine(new string('-', 30));
            Console.WriteLine();
            json["users"] = new JValue(JsonConvert.SerializeObject(list));
            Console.WriteLine("Second approach (" + json["users"].Type + "):");
            Console.WriteLine();
            Console.WriteLine(json.ToString(Formatting.Indented));
        }
        class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
        }
    }
