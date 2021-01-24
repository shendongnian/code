        public DbSet<Person> Persons { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\\MSSQLLocalDB;Database=SandboxComplex;Trusted_Connection=True;Integrated Security=true;");
        }
    }
