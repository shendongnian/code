    class MuseumContext : DbContext
    {
        public DbSet<Museum> Museums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
