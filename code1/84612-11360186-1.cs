    public static string CreateTABLE(string connectionString, string tableName, DataTable table)
    {
        string sqlsc;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            sqlsc = "CREATE TABLE "+tableName+"(";
            for (int i = 0; i < table.Columns.Count; i++)
            {
                sqlsc += "\n [" + table.Columns[i].ColumnName + "] ";
                if (table.Columns[i].DataType.ToString().Contains("System.Int32"))
                        sqlsc += " int ";
                else if (table.Columns[i].DataType.ToString().Contains("System.DateTime"))
                        sqlsc += " datetime ";
                else if (table.Columns[i].DataType.ToString().Contains("System.String"))
                    sqlsc += " nvarchar(" + table.Columns[i].MaxLength.ToString() + ") ";
                else 
                    sqlsc += " nvarchar(" + table.Columns[i].MaxLength.ToString() + ") ";
                        
                if (table.Columns[i].AutoIncrement)
                    sqlsc += " IDENTITY(" + table.Columns[i].AutoIncrementSeed.ToString() + "," + table.Columns[i].AutoIncrementStep.ToString() + ") "; 
                if (!table.Columns[i].AllowDBNull)
                    sqlsc += " NOT NULL ";
                sqlsc += ",";
            }
            connection.Close();
        }
        return sqlsc.Substring(0,sqlsc.Length-1) + ")";
    }
