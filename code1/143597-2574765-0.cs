    public static class PriceConverter
    {
        private static readonly Dictionary<string, Action<Prices, decimal>> setters =
            CreateSetterDictionary();
        public static void SetPrice(this Prices p, string id, decimal newPrice)
        {
            Action<Prices, decimal> setter;
            if (setters.TryGetValue(id, out setter))
                setter(p, newPrice);
        }
        private static Dictionary<string, Action<Prices, decimal>>
            CreateSetterDictionary()
        {
            var dic = new Dictionary<string, Action<Prices, decimal>>();
            dic.Add("0D", (p, d) => p.Today = d);
            dic.Add("1D", (p, d) => p.OneDay = d);
            // etc.
            return dic;
        }
    }
