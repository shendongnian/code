     class CallWebService
     {
          public enum Result
          { Unknown, Success, NotAvailable, InvalidData } // etc
          public Call(string data)
          {
               Webservice.Server server = new Webservice.Server();
               string result = string.Empty;
               try
               {
                    result = server.getResult(data);
               }
               catch (Exception ex) // replace with appropriate exception class
               {
                    return Result.NotAvailable;
               }
               if (result == "OK") return Result.Success
               else return Result.InvalidData;
          }
     }
