    if (result == some condition)
                     {
                         var error = new
                         {
                             Error = new
                             {
                                 StatusCode = HttpStatusCode.Unauthorised,
                                 Message = "Invalid Credential...! ",
                                 InternalMessage = "Some message"
                             }
                         };
                         return Content(HttpStatusCode.Unauthorised, error);
                     }
