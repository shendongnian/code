        private static bool _Created = false;
        public ApplicationDbContext()
        {
            if (!_Created)
            {
                _Created = true;
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server = .\SQLSERVER; initial catalog = DBName; Integrated Security = True; MultipleActiveResultSets = True; App = EntityFramework & quot; ");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
