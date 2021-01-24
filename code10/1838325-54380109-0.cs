        [HttpGet("{id}")]
        public string Get(int id)
        {
And remember that curly braces are not valid in URIs (see RFC 3986). That's why it is safe for us to use it as a symbol that will be replaced later with the action parameter value. So you can make the url template become like this,
    [RefererFilter("/Users/ChangePassword/{id}")]
    public IActionResult PasswordChanged(int id)
    {
        return View();
    }
    [RefererFilter("/Users/EditUser/{id}/UserEmail/{email}")]
    public IActionResult EditUser(int id, string email)
    {
        return View();
    }
Then in the RefererFilter you will need to parse the value of the action parameter in OnActionExecuting method, could be like the following,
    public class RefererFilter : ActionFilterAttribute
    {
        private List<string> referers;
        public RefererFilter(params string[] _referers)
        {
            referers = new List<string>(_referers);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool valid = false;
            foreach (string referer in referers)
            {
                string r = referer;
                foreach(var arg in context.ActionArguments)
                {
                    r = r.Replace($"{{{arg.Key}}}", arg.Value.ToString());
                }
                if (context.HttpContext.Request.Headers["Referer"].ToString() == $"https://{context.HttpContext.Request.Host.Value}{r}")
                {
                    valid = true;
                    break;
                }
            }
            if (!valid)
                context.Result = new StatusCodeResult(403);
            base.OnActionExecuting(context);
        }
    }
