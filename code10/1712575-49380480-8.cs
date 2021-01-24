    var entities = context.TblBases
        .Where(b => b.Id == _entity.Id)
        .ToList();
    var concreteEntity = entities
        .Where(e => ObjectContext.GetObjectType(e.GetType()) == ObjectContext.GetObjectType(_entity.GetType()))
        .Single();
    
    if (concreteEntity.COID.GetValueOrDefault() == 0)
    {
        //not assigned
    }
    else
    {
        //assigned
    }
    
