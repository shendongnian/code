    // Don't hard coded the connection string here. Get it from web.config as follows
    string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    using (var connection = new SqlConnection(connectionString))
    {
       connection.Open();
       // Do your necessary staffs here.
    }
