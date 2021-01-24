    public DatabaseConnection(IConfiguration configuration)
    {
          string connectionString = configuration.GetConnectionString("DefaultConnection");
          sqlAdapter = new SqlDataAdapter();
          sqlConnection = new SqlConnection(connectionString);
    }
