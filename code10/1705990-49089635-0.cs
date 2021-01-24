    public static class Rarities
    {
        private static List<string> _rarityValues = new List<string>()
        {
            "Empty",
            "Very Common",
            "Common",
            "Standard",
            "Rare",
            "Very Rare"
        };
        public static string ToRarityString(this int rarity)
        {
            return _rarityValues[rarity];
        }
        public static int ToRairityInt(this string rarity)
        {
            return _rarityValues.IndexOf(rarity);
        }
    }
