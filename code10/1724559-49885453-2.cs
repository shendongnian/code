    public static List<String> processData(IEnumerable<string> lines)
    {
        Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
        foreach (var item in lines)
        {
            string[] readsplitted = item.Split(',');
            keyValuePairs.Add(readsplitted[0], Convert.ToInt32(Regex.Replace(readsplitted[2], "[^0-9]+", string.Empty)));
        }
        var MaxVersion = keyValuePairs.Values.OrderByDescending(f => f).First();
        List<String> retVal = keyValuePairs.Where(f => f.Value == MaxVersion).Select(f => f.Key).ToList();
        return retVal;
    }
