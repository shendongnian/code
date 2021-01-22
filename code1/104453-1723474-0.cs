    public delegate void TransactionRunner(DbConnection sender, DbTransaction trans, object state);
    public void RunTransaction(TransactionRunner runner, object state)
        {
            RunTransaction(runner, IsolationLevel.ReadCommitted, state);
        }
    public void RunTransaction(TransactionRunner runner, IsolationLevel il, object state)
        {
            DbConnection cn = GetConnection from pool
            DbTransaction trans = null;
            try
            {  
                trans = cn.BeginTransaction(il);
                runner(cn, trans, state);
                trans.Commit();
            }
            catch (Exception err)
            {
                if (trans != null)
                    trans.Rollback();
                throw err;
            }
            finally
            {
                //Here you can close anything that was left open
            }
        }
