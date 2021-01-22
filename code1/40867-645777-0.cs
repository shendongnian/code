    OleDbCommand command = new OleDbCommand();
    SetCommandType(command, CommandType.StoredProcedure, "NameOfQueryInAccessDatabase");
    AddParamToSQLCmd(command, "@LastPolledDtgArg", OleDbType.Date, 4, ParameterDirection.Input, DateTime.Now);
    AddParamToSQLCmd(command, "@ID", OleDbType.Integer, 4, ParameterDirection.Input, id);
    using (OleDbConnection connection = new OleDbConnection("connectionString"))
    {
    command.Connection = connection;
    connection.Open();
    result = command.ExecuteNonQuery();
    }
