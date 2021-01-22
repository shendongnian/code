    public IEnumerable<object> RandomValues(Dictionary<string, object> dict)
    {
        Random rand = new Random();
        List<string> keys = Enumerable.ToList(dict.Keys);
        while(true)
        {
            yield return dict[keys[rand.Next(keys.Count)]];
        }
    }
