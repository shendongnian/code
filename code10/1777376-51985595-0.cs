    using (var db = new ApplicationDbContext())
    {
        if (client.Category != null) db.Set<Category>().Attach(client.Category);
        if (client.Subcategory != null) db.Set<Category>().Attach(client.Subcategory);
        db.Set<Client>().Add(item);
        db.SaveChanges();    
    }
