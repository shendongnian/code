    public class SampleController : Controller
    {
        [DynamicUrl]
        public ActionResult Index(int param2)
        {
            return View(param2);
        }
        [DynamicUrl]
        public ActionResult MultipleParams(int param1, int param2)
        {
            return View(new { param1, param2 });
        }
    }
