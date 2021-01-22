    string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\myfile.xls;Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";
    string provider = "System.Data.OleDb";
    DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
    DbConnection connection = factory.CreateConnection();
    connection.ConnectionString = connectionString;
    connection.Open();
    DbCommand command = connection.CreateCommand();
    command.CommandText = "SELECT * FROM [Sheet1$]"
    DbDataReader reader = command.ExecuteReader();
    while(reader.read()) {
        // process row
    }
