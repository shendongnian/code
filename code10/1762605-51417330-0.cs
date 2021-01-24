    public class BaseController : ApiController {
            [HttpPost]
            public virtual  IHttpActionResult Post(T entity)
            {
                return Ok();
            }
    
            [HttpPut]
            public virtual IHttpActionResult Put(T entity)
            {
                return Ok();
            }
    }
