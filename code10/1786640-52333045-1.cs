    OracleParameter [] parameters = {
        new OracleParameter("P_COUNTER_TYPE", OracleDbType.Varchar2, "ANALYZERS.STRING_COUNTER", ParameterDirection.Input);
        ...
    };
    command.Parameters.AddRange(parameters);
