     private readonly string dbConnection;
     public DatabaseContext(IConfiguration configuration) => dbConnection = configuration.GetConnectionString("dbConnection");
     public bool Insert(string query, params SqlParameter[] parameters)
     {
          // If no parameters, then you really are not inserting.  Handle exception.
          using(var connection = new SqlConnection(dbConnection))
               using(var command = new SqlCommand(connection, query))
               {
                    connection.Open();
                    command.Parameters.AddRange(parameters);
                    return (command.ExecuteNonQuery() > 0);
               }
     }
    
