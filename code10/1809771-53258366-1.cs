    class UniversityContext : DbContext
    {
         public DbSet<Department> Departments {get; set;}
         public DbSet<Student> Students {get; set;}
    }
