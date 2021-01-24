            DataTable dataTable = new DataTable();
            using (OracleConnection oracleConnection = new OracleConnection(constr))
            {
                oracleConnection.Open();
                OracleCommand oracleCommand = new OracleCommand(query, oracleConnection);
                OracleDataAdapter da = new OracleDataAdapter(oracleCommand);
                
                //TODO: This seems to get all the data. We just want 1 row or no rows and only column info..
                da.Fill(dataTable);
                oracleConnection.Close();//Close just in case
            }
            foreach (DataColumn column in dataTable.Columns)
            {
                //Use these properties to generate a class
                column.ColumnName;
                column.DataType;
                column.AllowDBNull; 
                column.DefaultValue;
            }
