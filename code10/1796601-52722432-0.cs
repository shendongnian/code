    var entry = _context.Entry(entity);
    if (entry.State == EntityState.Detached)
    {
        var dbset = _context.Set<EntityType>();
        dbset.Attach(entity);
    }
    entry.state = EntityState.Modified;
    _context.SaveChanges();
