     With reflection you can obtain the Id property.
    
    public override int Create<T>(T entity)
        {
            string entitySet = GetEntitySetName<T>();
            _context.AddObject(entitySet, entity);
            _context.SaveChanges();
    
             var idProperty = item.GetType().GetProperty("Id").GetValue(entity,null);
             return (int)idProperty;
        }
