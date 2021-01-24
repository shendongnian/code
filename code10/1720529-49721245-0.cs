    [Route("api/candidate/free")]
    public class MyController : Controller {
        //...
        //DELETE api/candidate/free/123
        [HttpDelete("{dateRangeId:int}")]
        public IActionResult MyAction(int dateRangeId) {
        
            //...
            
            return Ok();
        }
        
    }
