    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                string test = "[[[671, 1]],[[2011,1],[1110,1]],[[2001,1],[673,1]],[[1223,1],[617,1],[685,1]],[[671,1],[1223,2],[685,1]]]";
                var result = JsonConvert.DeserializeObject<List<List<List<int>>>>(test);
                for (int i = 0; i < result.Count; ++i)
                {
                    Console.WriteLine($"Page: {i}");
                    for (int j = 0; j < result[i].Count; ++j)
                        Console.WriteLine($"Row {j}: " + string.Join(", ", result[i][j]));
                }
            }
        }
    }
