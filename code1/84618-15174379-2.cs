    public static string CreateTABLEPablo(string connectionString, string tableName, System.Data.DataTable table)
    {
        string sqlsc;
        //using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
        using (System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection(connectionString))
        {
            connection.Open();
            sqlsc = "CREATE TABLE " + tableName + "(";
            for (int i = 0; i < table.Columns.Count; i++)
            {
                sqlsc += "\n" + table.Columns[i].ColumnName;
                if (table.Columns[i].DataType.ToString().Contains("System.Int32"))
                    sqlsc += " int ";
                else if (table.Columns[i].DataType.ToString().Contains("System.DateTime"))
                    sqlsc += " datetime ";
                else if (table.Columns[i].DataType.ToString().Contains("System.String"))
                    sqlsc += " nvarchar(" + table.Columns[i].MaxLength.ToString() + ") ";
                else if (table.Columns[i].DataType.ToString().Contains("System.Single"))
                    sqlsc += " single ";
                else if (table.Columns[i].DataType.ToString().Contains("System.Double"))
                    sqlsc += " double ";
                else
                    sqlsc += " nvarchar(" + table.Columns[i].MaxLength.ToString() + ") ";
                if (table.Columns[i].AutoIncrement)
                    sqlsc += " IDENTITY(" + table.Columns[i].AutoIncrementSeed.ToString() + "," + table.Columns[i].AutoIncrementStep.ToString() + ") ";
                if (!table.Columns[i].AllowDBNull)
                    sqlsc += " NOT NULL ";
                sqlsc += ",";
            }
            string pks = "\nCONSTRAINT PK_" + tableName + " PRIMARY KEY (";
            for (int i = 0; i < table.PrimaryKey.Length; i++)
            {
                pks += table.PrimaryKey[i].ColumnName + ",";
            }
            pks = pks.Substring(0, pks.Length - 1) + ")";
           
            sqlsc += pks;
            connection.Close();
            
        }
        return sqlsc + ")";
    }
