    OracleCommand cmd = OracleConnection1.CreateCommand();
    cmd.CommandText = "INSERT INTO ArrayTable VALUES (:CODE, :TITLE, : ARR1, :ARR2)";
    ...
    OracleArray arr1 = new OracleArray("SCOTT.TARRAY1", OracleConnection1);
    arr1.Add(10);
    arr1.Add(20);
    arr1.Add(30);
    ...
    cmd.Parameters["ARR1"].DbType = OracleDbType.Array;
    cmd.Parameters["ARR1"].Value = arr1;
    ...
    cmd.ExecuteNonQuery();
