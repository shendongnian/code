    using Microsoft.AspNetCore.Mvc;
    namespace Api
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public class DefaultController : Controller
        {
            [Route("/")]
            [Route("/docs")]
            [Route("/swagger")]
            public IActionResult Index()
            {
                return new RedirectResult("~/swagger");
            }
        }
    }
