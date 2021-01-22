    // connection string will be like "Server=(local);DataBase=Northwind;Integrated Security=SSPI"
    
    // instantiate and open connection
    using( var conn =  new SqlConnection(connectionString) )
    {
        conn.Open();
        var cmd = new SqlCommand("select * from Customers where city = @City", conn);
    
        // define parameters used in command object
        cmd.Parameters.Add( new SqlParameter{ ParameterName = "@City", Value = inputCity });
    
        using( var reader = command.ExecuteReader() )
        {
            // write each record
            while(reader.Read())
            {
                Console.WriteLine("{0}, {1}", reader["CompanyName"], reader["ContactName"]);
            }
        }
    }
