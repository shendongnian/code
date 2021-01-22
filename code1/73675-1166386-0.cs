    //Open the database
    using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + filepath + ";Version=3;")) {
      conn.Open();
      using (SQLiteCommand cmd = new SQLiteCommand(conn)) {
        using (SQLiteTransaction transaction = conn.BeginTransaction()) {
          //Here I do some stuff to the database, update, insert etc
          transaction.Commit();
        }
      }
    }
