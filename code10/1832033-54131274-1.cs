    using(var conn = new SqlConnetion(Oconnection))
    {
       conn.Open();
       using(var command = new SqlCommand())
       {
          command.Connection = conn; // grabbed from you post
          command.CommandTimeout = <higher value>;
          // add additional code for command here
       }
    }
