        OleDbCommand command = new OleDbCommand();
        command.Connection = connection;
        command.CommandText = "select * ... ";
        DataTable zDataTable = new DataTable;
        OleDbDataAdapter zDataAdapter = new OleDbDataAdapter;
        zDataAdapter.SelectCommand = command;
        zDataAdapter.Fill(zDataTable);
        int RecordCount = DataTable.Rows.Count;
