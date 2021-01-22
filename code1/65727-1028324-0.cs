    public IEnumerable<object> RandomValues()
    {
        Random rand = new Random();
        Dictionary<string, object> dict = GetDictionary();
        List<string> keys = dict.ToList();
        while(true)
        {
            yield return dict[keys[rand.Next(keys.Count)]];
        }
    }
    
