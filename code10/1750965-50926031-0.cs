    var data = new Dictionary<int, string>
    {
        { 1, "Red" }, 
        { 4, "Blue" },
        { 13, "Green" }
    };
    public string GetColor(int key)
    {
         if (dictionary.ContainsKey(key))
         {
                int value = dictionary[key];
                return value;
         }
         return string.Empty;
    }
