    public static class RarityRepository
    {
        private static Dictionary<int, string> _values = new Dictionary<int, string>()
        {  
            { 1, "Very Common" },
            { 2, "Common" },
            { 3, "Standard" },
            { 4, "Rare" },
            { 5, "Very Rare" },
        };
        public static string GetStringValue(int input)
        { 
            if(_values.ContainsKey(input))
            {
                return _values[input];
            }
            return string.Empty;
        }
        public static int GetIntValue(string input)
        {
            var result = _values.FirstOrDefault(x => string.Compare(x.Value, input, true) == 0);
		    if (result.Equals(default(KeyValuePair<int,string>)))
		    {
			    return -1; // returns -1 if no matches are found
		    }
            return result.Key;
        }
    }
