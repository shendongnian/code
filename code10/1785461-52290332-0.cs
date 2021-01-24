    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            var items = new[]
            {
                 new { Number = 1, OriginatesFrom = (int?) null, LastChanged = new DateTime(2018,5,3) },
                 new { Number = 2, OriginatesFrom = (int?) null, LastChanged = new DateTime(2018,5,3) },
                 new { Number = 3, OriginatesFrom = (int?) null, LastChanged = new DateTime(2018,5,3) },
                 new { Number = 4, OriginatesFrom = (int?) 1, LastChanged = new DateTime(2018,5,1) },
                 new { Number = 5, OriginatesFrom = (int?) 2, LastChanged = new DateTime(2018,5,1) },
                 new { Number = 6, OriginatesFrom = (int?) 1, LastChanged = new DateTime(2018,5,7) },
                 new { Number = 7, OriginatesFrom = (int?) 1, LastChanged = new DateTime(2018,5,4) },
                 new { Number = 8, OriginatesFrom = (int?) 3, LastChanged = new DateTime(2018,5,13) },
                 new { Number = 9, OriginatesFrom = (int?) 1, LastChanged = new DateTime(2018,5,13) },
                 new { Number = 10, OriginatesFrom = (int?) 3, LastChanged = new DateTime(2018,5,10) },
                 new { Number = 11, OriginatesFrom = (int?) 3, LastChanged = new DateTime(2018,5,18 )}
            };
            
            var query = items
                .GroupBy(x => x.OriginatesFrom ?? x.Number)
                .Select(g => g.OrderByDescending(x => x.OriginatesFrom)
                              .ThenByDescending(x => x.LastChanged)
                              .ToList())
                .OrderBy(g => g.First().LastChanged)
                .SelectMany(g => g)
                .ToList();
            
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }        
        }
    }
