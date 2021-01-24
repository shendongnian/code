    static void Main(string[] args)
    {
        List<Item> items = new List<Item>();
    
        items.Add(new Item("Bread", 2.50M));
        items.Add(new Item("Milk", 3.00M));
        items.Add(new Item("Juice", 4.50M));
        items.Add(new Item("Chocolate", 1.50M));
        items.Add(new Item("Cheese", 2.50M));
        items.Add(new Item("Ham", 3.50M));
        items.Add(new Item("Chicken", 13.50M));
    
        string result = PrintList(itemsNames, itemsPrices);
    
        Console.WriteLine("\r\nPress enter to continue...");
        Console.ReadKey();
    }
    
    public static string PrintList(List<Item> items)
    {
        var stringBuilder = new StringBuilder();
        for (int i = 0; i < items.Count; i++)
        {
            string names = items[i].Name;
            decimal prices = items[i].Price;
            sb.AppendLine($"The {names} costs ${prices}");
        }
        return sb.ToString();
    }
