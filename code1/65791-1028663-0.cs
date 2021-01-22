    string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\temp\Data.xls;Extended Properties=""Excel 8.0;HDR=YES;""";
    DbProviderFactory factory = DbProviderFactories.GetFactory ( "System.Data.OleDb" );
    using ( DbConnection connection = factory.CreateConnection ( ) )
    {
        connection.ConnectionString = connectionString;
        using ( DbCommand command = connection.CreateCommand ( ) )
        {
            // Cities$ comes from the name of the worksheet
            command.CommandText = "SELECT ID  FROM [Sheet1$]";
            connection.Open ( );
            using ( DbDataReader dr = command.ExecuteReader ( ) )
            {
                DataSet cities = new DataSet ( );
                cities.Load( dr, LoadOption.OverwriteChanges, new[]{"Sheet1"} );
            }
        }
    }
    return;
}
