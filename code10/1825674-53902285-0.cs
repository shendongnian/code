    class MyObj
    {
        public List<Dictionary<string, object>> PremiumStructure;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText("test.json"); // the file contains your json example
            var myObj = JsonConvert.DeserializeObject<MyObj>(text);
            foreach (var item in myObj.PremiumStructure)
            {
                foreach (var key in item.Keys)
                {
                    Console.WriteLine($"Key: {key} Value: {item[key]}");
                }
            }
            
            Console.ReadLine();
        }
    }
