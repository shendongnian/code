    private List<KeyValuePair<int, Dictionary<string, float>>> CreateResult(List<Dictionary<string, object>> items)
    {
        var result = new List<KeyValuePair<int, Dictionary<string, float>>>();
    
        for (int i = 0; i < items.Count; i++)
        {
           var item = items[i].ToDictionary<string, float>(v => v.Key, v = (float)v.Value);
           result.Add(new KeyValuePair<int, Dictionary<string, float>>(i, item));
        }
        return result;
    }
