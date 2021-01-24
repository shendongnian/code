    public class MedewerkerMeldingContext : DbContext
    {
        public DbSet<medewerker> medewerker { get; set; }
        public DbSet<medewerker_melding> medewerker_melding { get; set; }
    }
