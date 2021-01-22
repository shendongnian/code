    public static IList<IObject> SumAccounts(IEnumerable<IObject> data)
    {
        List<IObject> ret = new List<IObject>();
        foreach (var item in data)        
        {
            IObject existing = ret.Find(x => x.Account == item.Account);
            if (existing == null)
            {
                existing = new IObject(item.Account, 0m);
                ret.Add(existing);
            }
            existing.Amount += item.Amount;
        }
        return ret;
    }
