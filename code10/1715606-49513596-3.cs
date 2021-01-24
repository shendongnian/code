    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>().Property(e => e.Uri)
            .HasConversion(
                uri => uri?.ToString(),
                url => Uri.TryPrase(url, out Uri uri)?uri:null
            );
    }
