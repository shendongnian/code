    var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
    if (isSqlServer) //don't mind where it comes from, it works fine
        optionsBuilder.UseSqlServer(connectionString);
    else
        optionsBuilder.UseSqlite(connectionString);
    using (var context = new MyDbContext(optionsBuilder.Options))
    {
        // ...
    }
