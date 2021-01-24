    string allParams = "CML, ABC, DEF";
    string formattedParams = allParams.Replace(" ", string.Empty); // Or a custom format
    string [] splitParams = formattedParams.Split(',');
    List<OracleParamter> parameters = new List<OracleParameter>();
    string sql = @"SELECT * FROM FooTable WHERE FooValue IN (";
    for(int i = 0; i < splitParams.Length; i++)
    {
        sql += @":FooParam" + i + ",";
        parameters.Add(new OracleParameter(":FooParam" + i, OracleDbType.Varchar2, splitParams[i], ParameterDirection.Input));
    {
    sql = sql.Substring(0, (sql.Length - 1));
    sql += ')';
