    class Program
    {
        static void Main(string[] args)
        {
            string str = File.ReadAllText(@"Path to your json file");
            //Step 1
            JToken jToken = JToken.Parse(str);
            //Step 2 to 4
            var result = jToken.SelectTokens("..Es").Select(x => x.Select(y => (JObject)y).OrderBy(z => z["Total"])).ToList();
            //Step 5
            foreach (var i in result)
            {
                foreach (var j in i)
                    Console.WriteLine($"Type: {j["Type"]} \t Total: {j["Total"]}");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
    
