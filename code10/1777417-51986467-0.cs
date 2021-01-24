    public class NormalizeAttribute : ActionFilterAttribute
    {
        private readonly string _parameter;
        public NormalizeAttribute(string parameter)
        {
            _parameter = parameter;
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //Get the value passed in
            var value = (string)actionContext.ActionArguments[_parameter];
            //Trim, uppercase, reverse and put the value back in the parameter dictionary
            actionContext.ActionArguments[_parameter] = new string(
                value.Trim().ToUpper().Reverse().ToArray());
            base.OnActionExecuting(actionContext);
        }
    }
