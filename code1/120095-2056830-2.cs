    using System.Collections.Generic;
    
    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<Item>()
            { 
                new Item() { DisplayText = "A" },
                new Item() { DisplayText = "B" },
                new Item() { DisplayText = "AB" },
            };
    
            var res = filter(items, "A");
        }
    
        static List<T> filter<T>(List<T> items, string searchText) where T : Item
        {
            List<T> results = new List<T>();
            foreach (T item in items)
                if (item.DisplayText.ToLower().Contains(searchText.ToLower()))
                    results.Add(item);
            return results;
        }
    }
    
    class Item
    {
        public string DisplayText { get; set; }
    }
