    public DbSet<Phrase> Phrases { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //...
        modelBuilder.Entity<Phrase>()
            .HasDiscriminator(p => p.PhraseType)
            .HasValue<EnglishPhrase>(PhraseType.English)
            .HasValue<SpanishPhrase>(PhraseType.Spanish);
    }
