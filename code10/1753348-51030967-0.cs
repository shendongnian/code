    public virtual Domains.Vegetable.Result Get<T>(T entity) where T: Domains.Vegetable.Entity
    {
        var type = typeof(T);
        var info = type.GetProperty("Segment");
        var value = info.GetValue(entity).ToString(); // throws exception
        // other stuff
    }
