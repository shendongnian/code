    public static class LinqHelper
    {
        public static IEnumerable<List<Item>> Partition(this IEnumerable<Item> source, Func<Item, bool> selector)
        {
            List<Item> currentList = new List<Item>();
    
            foreach (var item in source)
            {
                if (selector(item))
                {
                    currentList.Add(item);
                }
                else if (currentList.Count != 0)
                {
                    yield return currentList;
                    currentList = new List<Item>();
                }
            }
    
            if (currentList.Count != 0)
            {
                yield return currentList;
            }
        }
    }
    public class Item
    {
        public int Id { get; set; }
        public int Val { get; set; }
    }
    void Main()
    {
        var list = new List<Item>(){
            new Item{ Id = 1, Val = 0 },
            new Item{ Id = 2, Val = 0 },
            new Item{ Id = 3, Val = 1 },
            new Item{ Id = 4, Val = 1 },
            new Item{ Id = 5, Val = 1 },
            new Item{ Id = 6, Val = 1 },
            new Item{ Id = 7, Val = 0 },
            new Item{ Id = 8, Val = 0 },
            new Item{ Id = 9, Val = 0 },
            new Item{ Id = 10, Val = 0 },
            new Item{ Id = 11, Val = 1 },
            new Item{ Id = 12, Val = 1 },
            new Item{ Id = 13, Val = 0 },
            new Item{ Id = 14, Val = 0 },
        };
        
        var result = list.Partition(i => i.Val == 1).Where(i => true).ToList();
    }
