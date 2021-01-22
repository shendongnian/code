    DbProviderFactory factory;
    DbConnection connection;
    DbDataAdapter dataAdapter;
    void SetConnection(ConnectionStringSettings settings) {
        factory = DbProviderFactories.GetFactory(settings.ProviderName);
        if (factory != null) {
            if (connection == null) {
                connection = factory.CreateConnection();
                dataAdapter = factory.CreateDataAdapter();                    
                connection.ConnectionString = settings.ConnectionString;
            }
        }
    }
    public DataTable GetTable(string statement) {
        DataTable dataTable = null;
        if (connection != null) {
           dataAdapter.SelectCommand = connection.CreateCommand();
           dataAdapter.SelectCommand.CommandText = statement;
           dataTable = new DataTable();
           dataAdapter.Fill(dataTable);
        }
        else
           throw new Exception("Connection object null");
        
        return dataTable;
    }
