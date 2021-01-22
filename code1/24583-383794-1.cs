    DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
    DataTable tables = null;
    DataSet database = new DataSet();
    using (DbConnection connection = factory.CreateConnection())
    {
        connection.ConnectionString = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=True";
        string[] restrictions = new string[4];
        // Catalog
        restrictions[0] = "Northwind";
        // Owner
        restrictions[1] = "dbo";
        // Table - We want all, so null
        restrictions[2] = null;
        // Table Type - Only tables and not views
        restrictions[3] = "BASE TABLE";
        connection.Open();
        // Here is my list of tables
        tables = connection.GetSchema("Tables", restrictions);
        // fill the dataset with the table data
        foreach (DataRow table in tables.Rows)
        {
            string tableName = table["TABLE_NAME"].ToString();
            DbDataAdapter adapter = factory.CreateDataAdapter();
            DbCommand command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from [" + tableName + "]";
            adapter.SelectCommand = command;
            adapter.Fill(database, tableName);
        }
    }
