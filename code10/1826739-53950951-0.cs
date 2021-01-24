                catch ( Microsoft.Azure.Documents.DocumentClientException ex )
            {
               if ( ex.StatusCode == System.Net.HttpStatusCode.Conflict )
               {
                  // Unique key constraint violation ...
               }
               else
               {
                  // Some other issue ...
                  throw;
               }
