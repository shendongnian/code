    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["test_schema"].ConnectionString))
    {
        // the 'Query' method is provided by Dapper
        var users = connection.Query("SELECT id, first_name FROM users");
        // each object in 'users' will have .id and .first_name properties
        ViewBag.users = users;
    
    
        // to duplicate your sample code's behaviour of creating strings:
        var users = connection.Query("SELECT id, first_name FROM users")
            .Select(x => string.Concat(x.id, "\t", x.first_name))
            .ToList();
    }
