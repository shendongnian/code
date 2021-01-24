    class WebController
    {
        public Response restMethod()
        {
            var context = getYourDBCOntext();
            using(var dbContextTransaction = context.Database.BeginTransaction())
            {
                try {
                    // do something with the DB
                    context.Database.ExecuteSqlCommand( /* sql command */ );
  
                    // save changes
                    context.SaveChanges();
                    // commit transaction
                    dbContextTransaction.Commit();
                catch(Exception)
                {
                    // Rollback in case of an error
                    dbContextTransaction.Rollback();
                }
            }
        }
    }
