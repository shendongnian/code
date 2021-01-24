    class Program
    {
        static void Main(string[] args)
        {
            string json = "{\"Code\":0,\"Message\":\"OK\",\"Data\":{\"Houses\":[{\"Id\":1,\"Name\":\"House 1\",\"Area\":\"22.00\",\"ShortName\":\"H1\",\"FarmName\":\"Farm 1\"},{\"Id\":2,\"Name\":\"Farmi1 - House 1\",\"Area\":\"1000.00\",\"ShortName\":\"H1\",\"FarmName\":\"Farm 1\"}]}}";
            var obj = JsonConvert.DeserializeObject<MainClass>(json);
            ShowObject(obj);
            Console.Read();
        }
        static void ShowObject(MainClass obj)
        {
            Console.WriteLine("Code: " + obj.Code);
            Console.WriteLine("Message: " + obj.Message);
            Console.WriteLine("Data:\n " + obj.Data.Keys.ElementAt(0));
            foreach (var house in obj.Data.Values.ElementAt(0))
            {
                Console.WriteLine("  Id: " + house.Id);
                Console.WriteLine("  Name: " + house.Name);
                Console.WriteLine("  Area: " + house.Area);
                Console.WriteLine("  ShortName: " + house.ShortName);
                Console.WriteLine("  FarmName: " + house.FarmName);
                Console.WriteLine();
            }
        }
    }
    class MainClass
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public Dictionary<string, House[]> Data { get; set; }
    }
    class House
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public string ShortName { get; set; }
        public string FarmName { get; set; }
    }
