    OracleParameter [] parameters = {
        new OracleParameter("P_COUNTER_TYPE", OracleDbType.Varchar2, "ANALYZERS", ParameterDirection.Input);
        ...
    };
    command.Parameters.AddRange(parameters);
