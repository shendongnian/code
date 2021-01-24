    [Route("[controller]")]
    public class VersionController : Controller {
        IVersionService _repository;
        public VersionController(IVersionService repository) {
            _repository = repository;
        }
        //Match GET version/GetBackgroundId
        [HttpGet("[action]")]
        public IActionResult GetBackgroundId() {
            return Ok(_repository.GetBackgroundId());
        }
        //Match PUT version/SetBackgroundId?id=5
        [HttpPut("[action]")]
        public IActionResult SetBackgroundId([FromQuery]int id) {
            _repository.SetBackgroundId(id);
            return NoContent();
        }
     }
