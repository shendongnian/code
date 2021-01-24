    var entities = context.Entity1st;
    foreach (var entity in entities)
    {
        entity.Entity2nd = context.Entity2nd.Where(x => x.Entity1stId == entity.Id);
    }
    return entities;
