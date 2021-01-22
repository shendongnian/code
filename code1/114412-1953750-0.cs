    if (entity is IEnumerable)
    {
        foreach (var item in (IEnumerable) entity)
        {
           Session.Save(item);
        }
    }
    else
    {
        Session.Save(entity);
    }
