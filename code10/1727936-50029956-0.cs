    public class FrontEndController : ApiController
        {
            public HttpResponseMessage Test(string value)
            {
                if(!isValid(value))
                  {
                     //Generate error response here
                     return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Username");
                  }
            }
        }
