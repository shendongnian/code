    class Item
    {
        public Item(string name) { Name = name; }
        public string Name { get; set; }
    }
...
    List<Item> available = new List<Item>()
    {
        new Item("1"), new Item("1"), new Item("2"), new Item("3"), new Item("5")
    };
    
    List<Item> selected = new List<Item>()
    {
        new Item("1"),new Item("2"), new Item("3")
    };
    
    List<Item> stillAvailable = new List<Item>();
    List<Item> stillSelected = new List<Item>(selected);
    
    foreach (Item item in available)
    {
        Item temp = stillSelected.Find(i => i.Name == item.Name);
        if (temp == null)
            stillAvailable.Add(item);
        else 
            stillSelected.Remove(temp);
    }
