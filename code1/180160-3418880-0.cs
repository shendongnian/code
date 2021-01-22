        OleDbConnection con = new OleDbConnection(connectionString);
        DataSet tablesFromDB = new DataSet();
        DataTable schemaTbl;
        try
        {
            // Open the connection
            con.Open();
            object[] objArrRestrict = new object[] { null, null, null, "TABLE" };
            // Get the table names from the database we're connected to
            schemaTbl = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, objArrRestrict);
            // Not sure if this is correct syntax...fix it if it isn't :)
            String commandText = @"SELECT * FROM {0}";
            // Get each table name that we just found and get the schema for that table.
            foreach (DataRow row in schemaTbl)
            {
                DataTable dt = new DataTable();
                OleDbCommand command = new OleDbCommand(String.Format(commandText, row["TABLE_NAME"] as String), con);
                dt.Load(command.ExecuteReader(CommandBehavior.SchemaOnly));
                tablesFromDB.Tables.Add(dt);
            }
        }
