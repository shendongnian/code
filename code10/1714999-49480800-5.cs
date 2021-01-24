    static void Main(string[] args)
    {
        var items = new List<Item>();
        for (var i = 0; i < 2; i++)
        {
            var itemNumber = $"Item #{i + 1}";
            var item = new Item
            {
                Name = GetInputFromUser($"Enter {itemNumber} Name: "),
                Price = GetDecimalFromUser($"Enter {itemNumber} price: "),
                Quantity = GetIntFromUser($"Enter {itemNumber} Quantity: ")
            };
            items.Add(item);
        }
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
