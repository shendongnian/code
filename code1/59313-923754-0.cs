    using (DbTransaction dbTrans = myDBConnection.BeginTransaction())
    {
         using (DbCommand cmd = myDBConnection.CreateCommand())
         {
             ...
         }
         dbTrans.Commit();
    }
