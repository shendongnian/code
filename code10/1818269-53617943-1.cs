    // Maybe give it a better name.
    public static void ValidateThatConnectionHasDataSourceAndDatabase(this SqlConnection connection)
    {
        if (string.IsNullOrEmpty(connection.DataSource)) 
            throw new Exception("The connection has no datasource");
        if (string.IsNullOrEmpty(connection.Database)) 
            throw new Exception("The connection has no database");
    }
