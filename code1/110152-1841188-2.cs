    public override IQueryable<T> GetObjectQuery<T>()
    {
        if (!_table.ContainsKey(type))
        {
            _table[type] = new QueryTranslator<T>(
                _ctx.CreateObjectSet<T>();
        }
    
        return (IQueryable<T>)_table[type];
    }
 
