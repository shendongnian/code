    private DbDataReader ReadExcelSheet(string file, string sheet)
            {
                string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file + ";Extended Properties=Excel 8.0;";
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
                DbConnection connection = factory.CreateConnection();
                connection.ConnectionString = connStr;
                DbCommand command = connection.CreateCommand();
    
                string query = BuildSelectQuery(sheet, names_mapping);//you need column names here
    
                command.CommandText = query;
                connection.Open();
                DbDataReader dr = command.ExecuteReader();
                return dr;
            }
