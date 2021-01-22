    var Connection = new SqlConnection(conString);
    using (var command = new SqlCommand(queryString, Connection))
    {
        Connection.Open();
         command.ExecuteNonQueryReader();
        throw new Exception() // Connections were NOT closed after unit-test had been finished
         finished.  I closed them manually via SQL.  Expected behaviour
        }
