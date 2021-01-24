    // for class Item
    public string Name { get; private set; }
    public int Duration { get; private set; }
    public int Cost { get; private set; }
    // for class Inventory
    public List<Item> Items { get; private set; } = new List<Item>();
