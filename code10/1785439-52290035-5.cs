    using (OracleCommand cmd = new OracleCommand("BEGIN UPDATE_MYTABLE(:tableId); END;"), con))
    {
      cmd.CommandType = CommandType.Text;
      // or
      // OracleCommand cmd = new OracleCommand("UPDATE_MYTABLE"), con);
      // cmd.CommandType = CommandType.StoredProcedure;
      var par = cmd.Parameters.Add("tableId", OracleDbType.Varchar2, ParameterDirection.Input);
      par.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
      par.Value = sa;
      par.Size = sa.Length;
      cmd.ExecuteNonQuery();
    }
