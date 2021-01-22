    private Dictionary<Type, object> _table = new Dictionary<Type, object>();
    public override IQueryable<T> GetObjectQuery<T>()
    {
        if (!_table.ContainsKey(type))
        {
            _table[type] = new QueryTranslator<T>(
                _ctx.CreateQuery<T>("[" + typeof(T).Name + "]"));
        }
        
        return (IQueryable<T>)_table[type];
    }
