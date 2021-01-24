    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    
    public class Item
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        
        public override string ToString() => $"{Name}/{Symbol}";
    }
    
    public class Test
    {
        static void Main()
        {
            var json = File.ReadAllText("test.json");
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, Item>>(json);
            foreach (var entry in dictionary)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
