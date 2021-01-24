    [RoutePrefix("api/Trip")]
    public class TripApiController : ApiController {
        [Route("SaveRouting")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveRouting([FromBody] RouteModel route) {
            if(ModelState.IsValid) {
                string points = route.points; 
                int tripId = route.tripId;
                decimal totalMileage = route.totalMileage;
    
                // ......
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
