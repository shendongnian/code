    public class ValuesController : Controller
    {
        private IMvcDepency _depency;
        public ValuesController()
        {
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _depency = new MvcDepency(context.HttpContext.Request);
            base.OnActionExecuting(context);
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var path = _depency.PathValue;
            return new string[] { "PathValue", path };
        }
    }
