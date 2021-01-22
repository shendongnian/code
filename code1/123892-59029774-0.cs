    public static class NumbersAdapter
    {
        private static readonly Dictionary<string, string> Mapping = new Dictionary<string, string>
        {
            ["1"] = "One",
            ["2"] = "Two",
            ["3"] = "Three"
        };
        
        public static string GetValue(string key)
        {
            return Mapping.ContainsKey(key) ? Mapping[key] : key;
        }
    }
