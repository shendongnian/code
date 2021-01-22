    using(var connection = new SqlConnection("ConnectionName"))
    using(var command = new SqlCommand()
    {
       command.Connection = connection;
       // setup command
       var reader = command.ExecuteReader();
       // read from the reader
       reader.Close();
    }
