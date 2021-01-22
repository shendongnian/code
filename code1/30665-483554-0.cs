    public IEnumerable<T> FirstMethod()
    {
        var entities = from t in context.Products
                       where {some conditions}
                       select t;
    
        foreach( var entity in entities.AsEnumerable() )
        {
            entity.SomeProperty = {SomeValue};
            yield return entity;   
        }
    }
