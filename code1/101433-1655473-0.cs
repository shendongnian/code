    public ObjectQuery DoQuery<E>(Expression<Func<E, bool>> filter)
    {
        string entitySetName = GetEntitySetName(typeof(T)); 
        return (ObjectQuery<E>)_ctx.CreateQuery<E>(entitySetName).Include("ProductDetails").Where(filter);
    }
