    public class InTran
    {
        protected virtual string ConnString
        {
            get { return ConfigurationManager.AppSettings["YourDB"]; }
        }
        public void Exec(Action<DBTransaction> a)
        {
            using (var dbTran = new DBTransaction(ConnString))
            {
                try
                {
                    a(dbTran);
                    dbTran.Commit();
                }
                catch
                {
                    dbTran.Rollback();
                    throw;
                }
            }
        }
    }
