    public class ExampleController : Controller
    {
        public ActionResult Test(YourObject input)
        {
            return input.Number.ToString();
        }
    }
