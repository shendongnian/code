    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    class Test
    {
        static void Main()
        {
            var dictionary = new Dictionary<string, object>
            {
                { "a", "thisIsA" },
                { "b", 3 },
                { "c", 5 },
                { "key", "string" }
            };
            var json = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
