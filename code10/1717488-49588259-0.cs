    var foo = GetData();
    using (DatabaseContext db = new DatabaseContext())
    {
        // Resolve references
        if (foo.Bar != null)
            foo.Bar = await db.Bar.FirstOrDefaultAsync(x => x.Url == foo.Bar.Url);
        // Then add the entity
        db.Entry(foo).State = EntityState.Added;
    
        await db.SaveChangesAsync();
    }
