    class program
    {
        public static void Main()
        {
            string json = File.ReadAllText(@"Path to your json file");
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(json, settings);
            Console.WriteLine("id: " + rootObject.id);
            Console.WriteLine("success: " + rootObject.success);
            Console.WriteLine("errors.id: " + rootObject.errors.id);
            Console.WriteLine("errors.values: " + string.Join(",", rootObject.errors.values));
            Console.ReadLine();
        }
    }
