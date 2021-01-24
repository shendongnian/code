    public static List<Cat> CheckProperties(List<Cat> inCatList, Cat inQueryCat)
    {
        Dictionary<Cat, List<PropertyInfo>> dict = new Dictionary<Cat, List<PropertyInfo>>();
    
        foreach (PropertyInfo pI in inQueryCat.GetType().GetProperties())
        {
            var value = pI.GetValue(inQueryCat);
    
            if (value != null)
            {
                var cats = inCatList.Where(cat => cat.GetType().GetProperty(pI.Name).GetValue(cat).Equals(value));
    
                foreach (Cat cat in cats)
                {
                    if (dict.ContainsKey(cat))
                    {
                        dict[cat].Add(pI);
                    }
                    else
                    {
                        dict.Add(cat, new List<PropertyInfo>() {pI});
                    }
                }
            }
        }
    
        int max = Int32.MinValue;
        foreach (KeyValuePair<Cat, List<PropertyInfo>> keyValuePair in dict)
        {
            if (keyValuePair.Value.Count > max)
            {
                max = keyValuePair.Value.Count;
            }
        }
    
        return dict.Where(pair => pair.Value.Count == max).Select(pair => pair.Key).ToList();
    }
