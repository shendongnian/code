    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>() { new Item { Name = "Pasta", Children = new List<Item>() { new Item { Name = "Pasta", Children = null } } } };
            List<Item> pastas = GetItemsByName(items, "Pasta");
        }
        
        private static List<Item> GetItemsByName(List<Item> items, string name)
        {
            List<Item> found = new List<Item>();
            foreach (Item item in items)
            {
                if (item.Name == name)
                {
                    found.Add(item);
                }
                if (item.Children != null)
                {
                    found.AddRange(GetItemsByName(item.Children, name));
                }
            }
            return found;
        }
    }
    public class Item
    {
        public string Name { get; set; }
        public List<Item> Children { get; set; }
    }
