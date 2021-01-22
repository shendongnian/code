    public class ErrorController : Controller
        {
            public ErrorController()
            {
                //_logger = logger; // log here if you had a logger!
            }
    
            /// <summary>
            /// This is fired when the site gets a bad URL
            /// </summary>
            /// <returns></returns>
            public ActionResult NotFound()
            {
                // log here, perhaps you want to know when a user reaches a 404?
                return View();
            }
        }
    }
