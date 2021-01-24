    public void SaveStuff(object stuff)
    {
       using(var transaction = context.Database.BeginTransaction())
       {
            try
            {
                var s2 = new Service2(transaction, context.Database.Connection);
                context.[DbEntity].Add(stuff);
                s2.SaveOtherStuff("stuff");
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
       }
    }
    public class Service2
    {
        private DbContext context;
        public Service2(DbContextTransaction transaction, DbConnection connection)
        {
            context = new DbContext(connection, false);
            context.Database.UseTransaction(transaction);
        }
    
        public void SaveOtherStuff(object stuff)
        {
            context.[DbEntity].Add(stuff);
        }
    }
