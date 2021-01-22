    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class HttpParamActionAttribute : ActionNameSelectorAttribute
    {
        private readonly string actionName;
        public HttpParamActionAttribute(string actionName)
        {
            this.actionName = actionName;
        }
        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            if (actionName.Equals(methodInfo.Name, StringComparison.InvariantCultureIgnoreCase))
                return true;
            if (!actionName.Equals(this.actionName, StringComparison.InvariantCultureIgnoreCase))
                return false;
            var request = controllerContext.RequestContext.HttpContext.Request;
            return request[methodInfo.Name] != null;
        }
    }
