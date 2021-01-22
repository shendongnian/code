    public IEnumerable<MyObject> GetMyObjects(int? maxCost, string name)
    {
        var query = context.MyObjects;
        if (maxCost != null)
        {
            query = query.Where(mo => mo.Cost <= (int)maxCost);
        }
        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(mo => mo.Name == name);
        }
        return query;
    }
