    public static class RarityConverter
    {
        private static List<Tuple<int, string>> Rarities = new List<Tuple<int, string>>()
        {
            new Tuple<int, string>(1, "Very Common"),
            new Tuple<int, string>(2, "Common"),
            new Tuple<int, string>(3, "Standard"),
            new Tuple<int, string>(4, "Rare"),
            new Tuple<int, string>(5, "Very Rare"),
        };
        public static string ToString(int rarity)
        {
            return Rarities.FirstOrDefault(t => t.Item1 == rarity)?.Item2;
        }
        public static int? ToInt(string rarity)
        {
            return Rarities.FirstOrDefault(t => string.Compare(t.Item2, rarity, true) == 0)?.Item1;
        }
    }
