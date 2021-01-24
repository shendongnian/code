    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        [HttpGet("children")]
        public IActionResult GetAllFromChildren([FromQuery(Name="childrenIds")]int[] childrenIds)
        {
            // omitted for brevity
        }
    }
