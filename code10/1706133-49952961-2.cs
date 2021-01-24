    if (result == somecondition)
                 {
                     var error = new
                     {
                         Error = new
                         {
                             StatusCode = HttpStatusCode.InternalServerError,
                             Message = "Error in functionality...!",
                             InternalMessage = "Some message"
                         }
                     };
                     return Content(HttpStatusCode.InternalServerError, error);
                 }
