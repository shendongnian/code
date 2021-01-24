    protected override void OnModelCreating(ModelBuilder builder)
    {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //Build identity
            BuildIdentity(builder);
            builder.ApplyConfiguration(new PersonMap());
            builder.ApplyConfiguration(new ProjectMap());
    }
