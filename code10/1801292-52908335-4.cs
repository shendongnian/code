    class Program
    {
        static void Main(string[] args)
        {
            JRaw rawJson = CreateRawJson(); 
            List<int> ids = GetIds(rawJson).ToList(); 
            Console.Read();
        }
        //  Instantiates 1 million Data objects and then creates a JRaw object
        private static JRaw CreateRawJson()
        {
            var data = new List<Data>();
            for (int i = 1; i <= 1_000_000; i++)
            {
                data.Add(new Data(i));
            }
            string json = JsonConvert.SerializeObject(data);
            return new JRaw(json);
        }
    }
