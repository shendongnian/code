    public static void Main()
    {
        var providerName = "System.Data.OleDb";
        var connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                                "Data Source=output.mdb";
        var table = new DataTable {
                            Columns = {
                                new DataColumn("ID", typeof (int)),
                                new DataColumn("Name", typeof (string)) },
                            Rows = {
                                new object[] {1, "One"},
                                new object[] {2, "Two"} }
                        };
        SaveData(providerName, connectionString, table);
    }
    private static void SaveData(string providerName,
                                 string connectionString,
                                 DataTable table)
    {
        var factory = DbProviderFactories.GetFactory(providerName);
        var connection = factory.CreateConnection();
        connection.ConnectionString = connectionString;
        var command= factory.CreateCommand();
        command.Connection = connection;
        command.CommandText = "select ID, Name from Person";
        var adapter = factory.CreateDataAdapter();
        adapter.SelectCommand = command;
        var builder = factory.CreateCommandBuilder();
        builder.DataAdapter = adapter;
        adapter.Update(table);
    }
