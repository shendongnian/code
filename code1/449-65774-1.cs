    using (DbDataReader dr = cmd.ExecuteReader()) {
      if (dr.Read()) {
        int idxColumnName = dr.GetOrdinal("columnName");
        int idxSomethingElse = dr.GetOrdinal("somethingElse");
        do {
          Console.WriteLine(dr.GetString(idxColumnName));
          Console.WriteLine(dr.GetInt32(idxSomethingElse));
        } while (dr.Read());
      }
    }
