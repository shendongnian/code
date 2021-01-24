     public class ErrorController : ControllerBase
        {
            [Route("error/{code:int}")]
            public ActionResult Error(int code)
            {
                switch (code)
                {
                    case 404: return View("404");
                    case 500: return View("500");
                    default: return View("Unknown");
                }
            }
        }
