    var data = new Dictionary<int, string>
    {
        { 1, "Red" }, 
        { 4, "Blue" },
        { 13, "Green" }
    };
    public bool TryGetColor(int key, out string value)
    {
         if (dictionary.ContainsKey(key))
         {
                value = dictionary[key];
                return true;
         }
         value = string.Empty;
         return false;
    }
