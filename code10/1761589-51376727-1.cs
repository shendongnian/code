    static void Main(string[] args)
    {
        List<string> itemsNames = new List<string>();
        List<decimal> itemsPrices = new List<decimal>();
        itemsNames.Add("Bread");
        itemsNames.Add("Milk");
        itemsNames.Add("Juice");
        itemsNames.Add("Chocolate");
        itemsNames.Add("Cheese");
        itemsNames.Add("Ham");
        itemsNames.Add("Chicken");
        itemsPrices.Add(2.50M);
        itemsPrices.Add(3.00M);
        itemsPrices.Add(4.50M);
        itemsPrices.Add(1.50M);
        itemsPrices.Add(2.50M);
        itemsPrices.Add(3.50M);
        itemsPrices.Add(13.50M);
        CombineTheLists(itemsNames, itemsPrices);
        Console.WriteLine("\r\nPress enter to continue...");
        Console.ReadKey();
    }
    public static string CombineTheLists(List<string> itemNames, List<decimal> itemPrices)
    {
        var stringBuilder = new StringBuilder();
        for (int i = 0; i < itemNames.Count; i++)
        {
            string result = "";
            string names = itemNames[i];
            decimal prices = itemPrices[i];
            stringBuilder.AppendLine($"The {names} costs ${prices}");
        }
        return stringBuilder.ToString();
    }
