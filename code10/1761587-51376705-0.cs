    public static string CombineTheLists(List<string> itemNames, List<decimal> itemPrices)
    {
        var sb = new StringBuidler();
        for (int i = 0; i < itemNames.Count; i++)
        {
            string result = "";
            string names = itemNames[i];
            decimal prices = itemPrices[i];
            sb.AppendLine($"The {names} costs ${prices}");
        }
        return sb.ToString();
    }
