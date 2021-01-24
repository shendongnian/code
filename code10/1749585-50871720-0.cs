    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    class Test
    {
        static void Main()
        {
            var json = File.ReadAllText("test.json");
            var parsed = JObject.Parse(json);
            var cycles = new Cycles
            {
                cycles = parsed.Properties()
                    .Where(p => int.TryParse(p.Name, out _))
                    .ToDictionary(p => p.Name, p => p.Value.ToObject<Cycle>()),                  
                recordsCount = (int) parsed["recordsCount"]
            };
            Console.WriteLine(string.Join(", ", cycles.cycles.Keys));
        }
    }
