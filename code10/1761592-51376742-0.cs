    public static string CombineTheLists(List<string> itemNames, List<decimal> itemPrices)
        {
            for (int i = 0; i < itemNames.Count; i++)
            {
                string result = "";
                string names = itemNames[i];
                decimal prices = itemPrices[i];
                Console.WriteLine($"The {names} costs ${prices}");
            }
          return "somestring from CombineTheLists function";
        }
