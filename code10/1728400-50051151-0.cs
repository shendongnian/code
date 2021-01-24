    public class AController : Controller
    {
        [HttpGet]
        public IActionResult GetURLBController()
        {
            var url = Url.Action("ActionB", "BController");
            return Ok(url);
        }
    }
