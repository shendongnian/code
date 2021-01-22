    using System.Collections.Generic;
    
    static class Extensions
    {
        public static void AddRange<T>(this ICollection<T> collection, List<T> list)
        {
            foreach (var item in list)
            {
                collection.Add(item);
            }
        }
    }
    
    class Item {}
    
    class Test
    {
        static void Main()
        {
            var list = new List<Item>{ new Item(), new Item(), new Item() };
            var hashset = new HashSet<Item>();
            hashset.AddRange(list);
        }
    }
