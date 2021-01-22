      using(var Connection = new SqlConnection(conString))
      {
        using (var command = new SqlCommand(queryString, Connection))
        {    
           Connection.Open();
           command.ExecuteNonQueryReader();
           throw new Exception()  // Connections were closed after unit-test had been 
           //finished.  Expected behaviour
         }
      }
