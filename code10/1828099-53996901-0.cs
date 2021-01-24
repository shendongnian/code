    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    namespace JsonSerialize {
        public static class Program {
            private static Dictionary<string, string> dict = new Dictionary<string, string> {
                ["A"] = "Some text",
                ["B"] = null
            };
            public static void Main(string[] args) {
                Dictionary<string, string> filtered = dict.Where(p => p.Value != null).ToDictionary(p => p.Key, p => p.Value);
                String json = JsonConvert.SerializeObject(filtered, Formatting.Indented);
                Console.WriteLine(json);
            }
        }
    }
