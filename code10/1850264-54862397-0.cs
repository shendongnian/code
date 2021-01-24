    using System;
    using Newtonsoft.Json;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                string test = "[123,234,345,456]";
                var result = JsonConvert.DeserializeObject<int[]>(test);
                // This prints "123, 234, 345, 456"
                Console.WriteLine(string.Join(", ", result));
                string andBackAgain = JsonConvert.SerializeObject(result);
                // This prints "[123,234,345,456]"
                Console.WriteLine(andBackAgain);
            }
        }
    }
