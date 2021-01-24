    public virtual Domains.Vegetable.Result Get<T>(T entity) where T: Domains.Vegetable.Entity
    {
        var value = entity.Segment.ToString(); // throws exception
        // other stuff
    }
