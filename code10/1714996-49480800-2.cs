    static void Main(string[] args)
    {
        var items = new List<Item>();
        for (int i = 0; i < 2; i++)
        {
            var item = new Item();
            item.Name = GetInputFromUser("Enter Item Name: ");
            item.Price = GetDecimalFromUser("Enter item price: ");
            item.Quantity = GetIntFromUser("Enter Item Quantity: ");
            items.Add(item);
        }
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
