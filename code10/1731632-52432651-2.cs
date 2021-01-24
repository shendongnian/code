csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseLazyLoadingProxies()
        .UseSqlServer(myConnectionString);
        
Or when using AddDbContext:
    .AddDbContext<BloggingContext>(
    b => b.UseLazyLoadingProxies()
          .UseSqlServer(myConnectionString));
 
 3. EF Core will then enable lazy loading for any navigation property that can be overridden--that is, it must be virtual.
