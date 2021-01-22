    public IEnumerable<string> tryAdd(IEnumerable<string> items)
    {
        List<string> list = items.ToList();
        string obj = "";
        list.Add(obj);
    
        return list.Select(i => i);
    }
