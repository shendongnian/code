    class Program
    {
        static void Main(string[] args)
        {
            string json = "{\"Code\":0,\"Message\":\"OK\",\"Data\":{\"Houses\":[{\"Id\":1,\"Name\":\"House 1\",\"Area\":\"22.00\",\"ShortName\":\"H1\",\"FarmName\":\"Farm 1\"},{\"Id\":2,\"Name\":\"Farmi1 - House 1\",\"Area\":\"1000.00\",\"ShortName\":\"H1\",\"FarmName\":\"Farm 1\"}]}}";
            var obj = JsonConvert.DeserializeObject<MainClass>(json);
            Console.Read();
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
