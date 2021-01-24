        public static string CreateCustomJSON(string serviceName, string value)
        {
            var x = new Dictionary<string, string>();
            x.Add(serviceName, value);
            return JsonConvert.SerializeObject(x);
        }
        public static void Main()
        {
            Console.WriteLine(CreateCustomJSON("service1", "hello"));
            Console.WriteLine(CreateCustomJSON("service2", "John"));
        }
