    public virtual IEnumerable<T> GetAll<T>() where T : class
    {
        using (var ctx = new DataContext())
        {
            var table = ctx.GetTable<T>().ToList();
            return table;
        }
    }
