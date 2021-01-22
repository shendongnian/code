            var items = new[] 
            { 
                new { ID = 1, Amount = 4 }, 
                new { ID = 1, Amount = 5 },
                new { ID = 2, Amount = 5 },
                new { ID = 2, Amount = 3 },
            };
            var results = from item in items group item by item.ID into g select new { ID = g.Key, Avg = g.Average(item => item.Amount) };
            foreach (var result in results)
            {
                Console.WriteLine("{0} - {1}", result.ID, result.Avg);
            }
