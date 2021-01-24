    public class TestController : Controller
    {
        [Authorize(policy: "dynamicRole")]
        public string Test()
        {
            return "Hello World!";
        }
    }
