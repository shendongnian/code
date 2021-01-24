    public class SomeController : Controller
    {
        private readonly Email _email;
        public SomeController(Email email)
        {
            _email = email;
        }
        public IActionResult SomeAction()
        {
             // Use _email here.
             ...
        }
    }
