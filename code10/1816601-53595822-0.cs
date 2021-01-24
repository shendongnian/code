    class MyDbContext : DbContext
    {
         // probably already existing constructors:
         public MyDbContext() : base (...) { }
         public MyDbContext(string nameOrConectionString : base (nameOrConnectionString) { }
         // extra constructor for Effort, uses existing base constructor
         public MyDbContext(DbConnection existingConnection) : base(existingConnection) { }
         ... // DbSets etc
    }
