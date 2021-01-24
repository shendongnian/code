    public class MyController : Controller
    {
        public IActionResult GetName()
        {
            string myOwnName = this.BareName();
        }
    }
