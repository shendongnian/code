    var par = cmd.Parameters.Add(":ids", OracleDbType.Varchar2, ParameterDirection.Input);
    par.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
    par.Value = ids;
    par.Size = ids.Length;
    cmd.ExecuteQuery();
