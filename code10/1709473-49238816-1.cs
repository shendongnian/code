            OracleConnection conn = new OracleConnection("Your Oracle Connection string");
            Conn.Open;
            DataSet dataSet = new DataSet();
            OracleCommand cmd = new OracleCommand("your select table query");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            using (OracleDataAdapter dataAdapter = new OracleDataAdapter())
            {
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dataSet);
            }
            foreach (DataTable table in dataSet.Tables)
            {
                SqlTableManager tableManager = new SqlTableManager(table, "Your SQL Server Connection string");
                tableManager.SyncTableSchemas(); // Create or update the SQL Server table.
                tableManager.UploadTableToSql(); // Bulk load DataTable into the newly created table.
            }
