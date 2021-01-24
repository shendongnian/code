    MyTableAdapters.MyableAdapter contTa;
        try
            {
              contTa = new MyTableAdapters.MyableAdapter();
        
              contTa.Connection.BeginTransaction();
        
              contTa.Insert(myvalues);
        
              contTa.Transaction.Commit();
            }
            catch
            {
               contTa.Transaction.Rollback();
            }
