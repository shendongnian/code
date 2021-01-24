    public class MyController : ApiController
    {
        [HttpGet]
        [Route("MyController")]
        public IHttpActionResult MyInnerController(String action)
        {
            switch(action)
            {
                case "MyAction":
                    return MyAction();
            }
        
            return BadRequest("Invalid action: " + action);
        }
        
        public IHttpActionResult MyAction()
        {
            return Ok();
        }
    }
