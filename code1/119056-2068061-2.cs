    NpgsqlTransaction tr = (NpgsqlTransaction) Connection.BeginTransaction();
    NpgsqlCommand cursCmd = new NpgsqlCommand("someStoredProcedure", (NpgsqlConnection) Connection);
    cursCmd.Transaction = tr;
    NpgsqlParameter rf = new NpgsqlParameter("ref", NpgsqlTypes.NpgsqlDbType.Refcursor);
    rf.Direction = ParameterDirection.InputOutput;
    cursCmd.Parameters.Add(rf);
    NpgsqlParameter param2 = new NpgsqlParameter("param1", NpgsqlTypes.Int32);
    rf.Direction = ParameterDirection.Input;
    cursCmd.Parameters.Add(param2);
    NpgsqlDataReader r = cmd.ExecuteReader();
    while (r.Read())
    {
        ; // r.GetValue(0);
    }
    r.NextResult();
    while(r.Read())
    {
        ;
    }
    tr.Commit();
