    var par1 = cmd.Parameters.Add("IdList ", OracleDbType.Int16, ParameterDirection.Input);
    par1.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
    par1.Value = new int[] { 1, 2};
    par1.Size = 2:
    var par2 = cmd.Parameters.Add("ValueList ", OracleDbType.Int16, ParameterDirection.Input);
    par2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
    par2.Value = new int[] { 3, 4};
    par2.Size = 2:
