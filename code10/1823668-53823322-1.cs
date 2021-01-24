    [RoutePrefix("api/v1/user")]
    public class UserController : ApiController
    {
       public IHttpActionResult GetData()
       {
           //your logic
           return Ok(PersonDataAccess.Data);
       }
    }
