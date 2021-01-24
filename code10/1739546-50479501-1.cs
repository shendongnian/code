    public class Inventory
    {
        public List<Item> Items { get; set; }
        public Inventory()
        {
            Items = new List<Item>()
            {
                new Item("Ipod"),
                new Item("Samsung"),
                new Item("Motorolla"),
                new Item("Huawei")
            };
        }
    }
