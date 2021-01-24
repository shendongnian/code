    [Route("api/[controller]")]
    public class BuildingsController: Controller {
        
        //GET api/buildings/page=1&pageSize=10&predicate=fr
        [HttpGet("", Name = "GetBuildingsBySearchCriteria")]
        public IActionResult GetBuildingsBySearchCriteria([FromHeader]string idUser, [FromQuery]int page, [FromQuery]int pageSize, [FromQuery]string predicate) {
            //....
        }
    }
