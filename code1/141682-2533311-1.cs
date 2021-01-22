    public class Item
    {
        public Dictionary<string, string> Data { get; set; }
        public string GetValue(string key)
        {
            if (Data == null)
                return null;
            string result;
            Data.TryGetValue(key, out result);
            return result;
        }
    }
    public class ItemKeys
    {
        public const string Name = "Name";
        public const string Foo = "Foo";
    }
