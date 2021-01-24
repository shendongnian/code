    using(TheContext dbContext = new TheContext()) {
        dbContext.Configuration.UseDatabaseNullSemantics = true;
    
        ...
    
        if (email != null)
        {
            query = query.Where(r => r.Email == email);
        }
    }
