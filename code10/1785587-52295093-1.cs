    public class SomeController : Controller
    {
        public IActionResult SomeAction([FromServices] Email email)
        {
             // Use email here.
             ...
        }
    }
