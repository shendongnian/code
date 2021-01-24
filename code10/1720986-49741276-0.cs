    var connectionString = ConfigurationManager.ConnectionStrings["ConexaoProjetoDB"].ConnectionString;
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        // ...
    }
