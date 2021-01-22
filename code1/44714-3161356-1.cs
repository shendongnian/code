    public IQueryable<T> Repository<T>() where T : class
    {
        ITable table = _context.GetTable(typeof(T));
        return table.Cast<T>();
    }
