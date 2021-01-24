    using (var context = new SomeDbContext())
    {
     using (DbContextTransaction transaction = context.Database.BeginTransaction()) {
       //do stuff
       context.SaveChanges();
       // multiple saves
       context.SaveChanges();
       transaction.Commit(); // this is one transaction
     }
    }
