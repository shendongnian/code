    public interface IDbContextConfiguration {
        bool AutoDetectChangesEnabled { get; set; }
        // ... any other required members here ...
    }
    public class DbContextConfigurationAdapter : IDbContextConfiguration {
        DbContextConfiguration config;
        public DbContextConfigurationAdapter(DbContextConfiguration config) {
            this.config = config;
        }
        public bool AutoDetectChangedEnabled {
            get { return config.AutoDetectChangedEnabled; }
            set { config = value; }
        }
    }
