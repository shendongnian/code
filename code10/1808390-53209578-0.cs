    [Route("foo")]
    public class MyAwesomeController
    {
        [Route("bar")]
        public IActionResult MyAwesomeAction()
        {
            return View();
        }
    }
