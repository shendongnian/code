    static void Main(string[] args)
    {
        string providerName = @"System.Data.OracleClient";
        string connectionString = @"...";
    
        DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
        using (DbConnection connection = factory.CreateConnection())
        {
            connection.ConnectionString = connectionString;
            connection.Open();
            DataTable schemaDataTable = connection.GetSchema("Tables", new string[] { "schema name", "table name" });
            foreach (DataColumn column in schemaDataTable.Columns)
            {
                Console.Write(column.ColumnName + "\t");
            }
            Console.WriteLine();
            foreach (DataRow row in schemaDataTable.Rows)
            {
                foreach (object value in row.ItemArray)
                {
                    Console.Write(value.ToString() + "\t");
                }
                Console.WriteLine();
            }
        }
    }
