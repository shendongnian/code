    class Program
    {
        internal class ParsedObject
        {
            public string Name;
            public string Store;
        }
        static void Main(string[] args)
        {
            string json = @"
            {
                ""2"": 
                {
                    ""name"": ""Cannonball"",
                    ""store"": 5
                },
                ""6"": 
                {
                    ""name"": ""Cannon base"",
                    ""store"": 187500
                },
                ""8"": 
                {
                    ""name"": ""Cannon stand"",
                    ""store"": 187500
                }
            }";
            var jsonDeserialized = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, ParsedObject>>(json);
            Console.WriteLine(jsonDeserialized["2"].Name);
        }
    }
