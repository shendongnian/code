    public static IList<IObject> SumAccounts(IEnumerable<IObject> data)
    {
        List<IObject> ret = new List<IObject>();
        Dictionary<string, IObject> map = new Dictionary<string, IObject>();
        foreach (var item in data)        
        {
            IObject existing;
            if (!map.TryGetValue(item.Account, out existing))
            {
                existing = new IObject(item.Account, 0m);
                map[item.Account] = existing;
                ret.Add(existing);
            }
            existing.Amount += item.Amount;
        }
        return ret;
    }
