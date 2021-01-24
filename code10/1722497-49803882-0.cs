    [Route("/dev/test")]
    public class TestController : Controller {
        [HttpGet]
        public IActionResult Get() {
            return UnprocessedEntityResult();
        }
        [NonAction]
        public IActionResult UnprocessedEntityResult() {
            return StatusCode(StatusCodes.Status422UnprocessableEntity);
        }
    }
