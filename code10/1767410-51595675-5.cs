    public class DbContextFactory : IDbContextFactory {
    
        private readonly Func<AppDbContext> factory;
    
        public DbContextFactory(Func<AppDbContext> factory) {
            this.factory = factory;
        }
    
        public AppDbContext Create() {
            return factory();
        }
    }
