    public abstract class AbstractController<T> : ApiController {
        [HttpPost] // Or GET
        [Route("createfolder")]
        public IHttpActionResult CreateFolder<T>(long parent, string foldername) {
            T result = YourClass.CreateFolder<T>(parent, foldername);
            
            return Ok(result);
        }
    }
    
    [RoutePrefix("api/sql")]
    public abstract class SqlController : AbstractController<long> { }
    [RoutePrefix("api/csv")]
    public abstract class SqlController : AbstractController<string> { }
