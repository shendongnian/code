    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    
    class Root
    {
        public Dictionary<int, Property> Http { get; set; }
        public Dictionary<int, Property> Sip { get; set; }
    }
    
    class Property
    {
        public string Title { get; set; }
        public string Value { get; set; }
    }
    
    class Test
    {
        static void Main()
        {
            string json = File.ReadAllText("test.json");
            var root = JsonConvert.DeserializeObject<Root>(json);
            foreach (var entry in root.Http)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value.Title}/{entry.Value.Value}");
            }
        }
    }
