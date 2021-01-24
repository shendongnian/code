    using System;
    using Newtonsoft.Json;
    namespace Demo
    {
        public class Demo
        {
            public int player { get; set; }
            public int size { get; set; }
        }
        class Program
        {
            static void Main()
            {
                Demo result = JsonConvert.DeserializeObject<Demo>("{\"player\":0, \"size\":3}");
                Console.WriteLine(result.player); // "0"
                Console.WriteLine(result.size);   // "3"
            }
        }
    }
