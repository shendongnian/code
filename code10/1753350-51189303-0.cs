    public virtual Domains.Vegetable.Result Get<T>() where T: Domains.Vegetable.Entity, new()
    {
        var entity = new T();
        var segment = entity.Segment;
        // omitted for brevity
    }
