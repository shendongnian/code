    int retryCount = 3;
    bool success = false;  
    while (retryCount > 0 && !success) 
    {
      try
      {
         // your sql here
         success = true; 
      } 
      catch (SqlException exception)
      {
         if (exception.Number != 0x4b5)
         {
           // a sql exception that is not a deadlock 
           throw; 
         }
         // Add delay here if you wish. 
         retryCount--; 
      }
    }
