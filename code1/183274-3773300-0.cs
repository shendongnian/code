    using (var context = new MyObjectContext())
    {
        context.ContextOptions.ProxyCreationEnabled = true;
        var newEntity = context.CreateObject<MyEntity>();
        context.Add(newEntity);
        context.SaveChanges();
        // now GetObjectStateEntry(newEntity) should work just fine.
        // ...
    }
