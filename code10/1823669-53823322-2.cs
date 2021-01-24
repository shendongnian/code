    [RoutePrefix ("api/v1/user")]
    public class UserController : ApiController    
    {
        public IHttpActionResult GetData () 
        {
            //your logic
            return Ok (PersonDataAccess.Data);
        }
        public IHttpActionResult GetById (int id) 
        {
            Person person = PersonDataAccess.Data.FirstOrDefault (p => p.Id = id);
            if (person != null) {
                return Ok (person);
            } else {
                return NotFound ();
            }
            //your logic
        }
    }
