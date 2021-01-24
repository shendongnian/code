    public static List<String> processData(IEnumerable<string> lines)
    {
        var keyValuePairs = new Dictionary<string, int>();
        int Position = 0;
        foreach (var item in lines)
        {
            Position++;
            string[] readsplitted = item.Split(',');
            keyValuePairs.Add(Position.ToString() +"_" + readsplitted[0], Convert.ToInt32(Regex.Replace(readsplitted[2], "[^0-9]+", string.Empty)));
        }
        var MaxVersion = keyValuePairs.Values.OrderByDescending(f => f).First();
        return keyValuePairs.Where(f => f.Value == MaxVersion).Select(f => string.Join("_", f.Key.Split('_').Skip(1))).ToList();
    }
