    public virtual IEnumerable<T> GetAll<T>() where T : class, IHaveTheProperty
    {
        using (var ctx = new DataContext())
        {
            ctx.ObjectTrackingEnabled = false;
            var table = ctx.GetTable<T>().ToList().AsReadOnly().OrderBy(t=>t.TheProperty);
            return table;
        }
    }
