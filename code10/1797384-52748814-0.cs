    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp3
    {
        public class Item
        {
            public int ItemID { get; set; }
            public DateTime Date { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                List<Item> items = new List<Item>
                {
                    new Item { ItemID= 1, Date = new DateTime(2018, 10, 10, 11, 30, 0) },
                    new Item { ItemID= 1, Date = new DateTime(2018, 10, 10, 11, 32, 0) },
                    new Item { ItemID= 1, Date = new DateTime(2018, 10, 10, 11, 33, 0) },
                    new Item { ItemID= 1, Date = new DateTime(2018, 10, 10, 11, 34, 0) },
                    new Item { ItemID= 1, Date = new DateTime(2018, 10, 10, 11, 57, 0) },
                    new Item { ItemID= 2, Date = new DateTime(2018, 10, 10, 7, 45, 0) },
                    new Item { ItemID= 2, Date = new DateTime(2018, 10, 10, 7, 49, 0) },
                    new Item { ItemID= 2, Date = new DateTime(2018, 10, 10, 8, 45, 0) },
                    new Item { ItemID= 2, Date = new DateTime(2018, 10, 10, 9, 13, 0) }
                };
                var groupedItems = items.GroupBy(i => i.ItemID, (k, g) => g
              .GroupBy(i => (long)new TimeSpan(i.Date.Ticks - g.Min(e => e.Date).Ticks).TotalMinutes / 5));
                var groupIndex = 0;
                foreach (var group in groupedItems)
                {
                    foreach (IGrouping<long, Item> groupItem in group)
                    {
                        Console.Out.WriteLine("Group " + (++groupIndex));
                        foreach (var item in groupItem)
                        {
                            Console.WriteLine($"Item {item.ItemID}. Date: {item.Date}");
                        }
                        Console.Out.WriteLine();
                    }
                }
                Console.ReadLine();
            }
        }
    }
