     public void Configure(IApplicationBuilder app, IHostingEnvironment en, DbContext context)
     {
       ....
        context.EnsureIdUpdates();
        context.ApplyMigrations();
    }
   
    public static void ApplyMigrations(this DbContext dbContext, string[] excludeMigrations = null)
        {
            var pendingMigrations = dbContext.Database.GetPendingMigrations();
    
            foreach (var migration in pendingMigrations)
            {
                if (excludeMigrations != null && excludeMigrations.Contains(migration))
                    continue;
    
                dbContext.Database.Migrate(migration);
            }
        }
