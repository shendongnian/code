    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>().Property(e => e.Uri)
            .HasConversion(new UriConverter(
                uri => uri?.ToString(),
                uri => Uri.TryPrase(url, out Uri uri)?uri:null
            ));
    }
