    var attempt = 0;
    while (attempt < 2) 
    {
       try {
          cmd.ExecuteNonQuery();
          break;
       } catch (OracleException oe) {
          Console.Out.WriteLine("OracleException: {0}", oe.Message);
          if (oe.Code == -1012) {
             connection.Open();
             attempt++;
          }
       }
    }
    if (attempt == 2) {
      // you have a problem!
    }
