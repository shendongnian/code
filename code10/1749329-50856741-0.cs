    void InitCommand(OracleCommand command, bool shouldDelete) {
        command.Parameters.Add(new OracleParameter("ID_IN", OracleDbType.Decimal, 4, "ID"));    
        command.Parameters.Add(new OracleParameter("DELETE_IN", OracleDbType.Decimal)).Value =
            shouldDelete ? 1 : 0;
        command.Parameters.Add(new OracleParameter("SERIAL_IN", OracleDbType.Varchar2, 50,
            "SERIAL"));
    }
    InitCommand(ins_upd, shouldDelete: false);
    InitCommand(delete_rec, shouldDelete: true);
