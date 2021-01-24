    var foo = GetData();
    using (DatabaseContext db = new DatabaseContext())
    {
        // Resolve references
        if (foo.Bar != null)
        {
            var bar = await db.Bar.FirstOrDefaultAsync(x => x.Url == foo.Bar.Url);
            if (bar != null)
                foo.Bar = bar;
        }
        // Then add the entity
        db.Entry(foo).State = EntityState.Added;
    
        await db.SaveChangesAsync();
    }
