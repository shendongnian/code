    static List<int> FindCommon(List<List<int>> items)
    {
        Dictionary<int, int> oldList = new Dictionary<int, int>();
        Dictionary<int, int> newList = new Dictionary<int, int>();
    
        oldList = items[0].ToDictionary(x => x, x => x);
    
        foreach (List<int> list in items.Skip(1))
        {
            foreach (int i in list)
            {
                if (oldList.Keys.Contains(i))
                {
                    newList.Add(i, i);
                }
            }
    
            oldList = new Dictionary<int, int>(newList);
            newList.Clear();
        }
    
        return oldList.Values.ToList();
    }
