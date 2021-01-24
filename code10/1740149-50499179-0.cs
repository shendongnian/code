    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ServerRouteController : Controller {
        /// <summary>
        /// Load default index view
        /// </summary>
        /// <returns></returns>
        [Route("")]         //Match /ServerRoute
        [Route("[action]")] //Match /ServerRoute/Index
        public IActionResult Index() {
            return View();
        }
    }
