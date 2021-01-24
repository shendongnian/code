    using(var dbConnection = new SqlConnection("..."))
    using(var command = new SqlCommand(query, dbConnection))
    {
         dbConnection.Open();
         ...
    }
