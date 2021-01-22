    using (DbConnection conn = new SQLiteConnection(...)) {
       using (DbTransaction tran = conn.BeginTransaction()) {
          using (DbCommand comm = conn.CreateCommand()) {
              ...
          }
          tran.Commit();
       }
       conn.Close();
    }
