    class DbContext
    {
          public DbSet<School> Schools {get; } = new DbSet<School>{CsvFile = ...};
          public DbSet<Teacher> Teachers {get; } = new DbSet<Teacher> {CsvFile = ...};
          public DbSet<Student> Students {get; } = new DbSet<Student> {CsvFile = ...};
    }
