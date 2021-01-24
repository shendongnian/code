    [Route("/dev/test")]
    public class TestController : Controller {
        [HttpGet]
        public IActionResult Get() {
            return UnprocessedEntityResult();
        }
        protected IActionResult UnprocessedEntityResult() {
            return StatusCode(StatusCodes.Status422UnprocessableEntity);
        }
    }
