    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
        public static void Main()
        {
            var dataItems = new List<Data>
            {
                new Data { ID = 555, Name = "newname", Description = "a descript" },
                new Data { ID = 555, Name2 = "name2", Description2 = "Description2name" },
                new Data { ID = 543, Name = "onename", Description = "myname" },
            };
    
            var aggregate = dataItems
                .GroupBy(x => x.ID, x => x)
                .Select(g => g.Aggregate((current, next) =>
                {
                    current.Description = current.Description ?? next.Description;
                    current.Description2 = current.Description2 ?? next.Description2;
                    current.Name = current.Name ?? next.Name;
                    current.Name2 = current.Name2 ?? next.Name2;
                    return current;
                }));
    
            foreach (var item in aggregate)
            {
                Console.WriteLine($"{item.ID}\t{item.Name}\t{item.Description}\t{item.Name2}\t{item.Description2}");
            }
        }
    }
    
    
    public sealed class Data
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
    }
