    private static OracleCommand CreateUpdateDeleteCommand(OracleConnection connection,
        bool shouldDelete) {
        OracleCommand command = new OracleCommand("MyProcedure", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new OracleParameter("ID_IN", OracleDbType.Decimal, 4, "ID"));    
        command.Parameters.Add(new OracleParameter("DELETE_IN", OracleDbType.Decimal)).Value =
            shouldDelete ? 1 : 0;
        command.Parameters.Add(new OracleParameter("SERIAL_IN", OracleDbType.Varchar2, 50,
            "SERIAL"));
        return command;
    }
    private void InitializeAdapter() {
        da = new OracleDataAdapter();
        OracleConnection conn = new OracleConnection(conn_string);
        conn.Open();
        OracleCommand select = new OracleCommand("MySelectProcedure", conn);
        select.CommandType = CommandType.StoredProcedure;
        da.SelectCommand = select;
        da.UpdateCommand = CreateUpdateDeleteCommand(conn, shouldDelete: false);
        da.InsertCommand = CreateUpdateDeleteCommand(conn, shouldDelete: false);
        da.DeleteCommand = CreateUpdateDeleteCommand(conn, shouldDelete: true);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        conn.Close();
    }
