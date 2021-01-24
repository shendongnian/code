    [Route("api/[controller]")]
    public class CalculationController: Controller {
    
        //POST api/Calculation/Calculate
        [HttpPost("[action]")]
        public ActionResult<CoralResult> Calculate([FromBody]CoralRequest model) {
            if(ModelState.IsValid) {
                CoralResult result = new CoralResult();
                
                //...do something with model and populate result.
                
                return result;
            }
            return BadRequest(ModelState);
        }
        
    }
    
