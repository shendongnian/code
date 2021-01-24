    using System;
    using System.Linq;
    
    class Program
    {
        static void Main()
        {
            var input = new[]
            {
                new { CategoryId = 1, Value = "val1" },
                new { CategoryId = 1, Value = "val2" },
                new { CategoryId = 1, Value = "val2" },
                new { CategoryId = 2, Value = "test1" },
                new { CategoryId = 2, Value = "test1" },
                new { CategoryId = 3, Value = "data1" },
                new { CategoryId = 3, Value = "data2" },
                new { CategoryId = 3, Value = "data2" },
            };
            
            var query = input.GroupBy(
                item => item.CategoryId,              // Key
                item => item.Value,                   // Element
                // Projection of results
                (key, values) => new { Key = key, Values = values.Distinct() });
            
            foreach (var element in query)
            {
                Console.WriteLine($"{element.Key}: {string.Join(", ", element.Values)}");
            }
        }
    }
