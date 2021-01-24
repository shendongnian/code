    public  class ObjectController : BaseController {
        [HttpPut]
        [Route("api/Object")]
        public override IHttpActionResult Put(T entity)
        {
            return Ok();
        }
    }
