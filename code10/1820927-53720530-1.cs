    class SchoolContext : DbContext
    {
        public DbSet<School> Schools {get; set;}
        public DbSet<Student> Students {get; set;}
    }
