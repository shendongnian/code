       class Program
        {
            public class HourEntry
            {
                public int Id { get; set; }
                public int Hours { get; set; }
            }
    
            static void Main(string[] args)
            {
                List<HourEntry> hours = new List<HourEntry>
                {
                    new HourEntry { Id = 1, Hours = 3 },
                    new HourEntry { Id = 2, Hours = 4 },
                    new HourEntry { Id = 3, Hours = 3 },
                    new HourEntry { Id = 1, Hours = 8 },
                    new HourEntry { Id = 5, Hours = 2 },
                    new HourEntry { Id = 3, Hours = 2 },
                    new HourEntry { Id = 3, Hours = 6 },
                    new HourEntry { Id = 9, Hours = 2 },
                    new HourEntry { Id = 4, Hours = 2 },
                };
    
    
                var moreThanTen = from h in hours
                                  group h by h.Id into hGroup
                                  where hGroup.Sum(hg => hg.Hours) > 10
                                  select hGroup.Key;
    
                foreach (var m in moreThanTen)
                {
                    Console.WriteLine(m);
                }
            }
        }
