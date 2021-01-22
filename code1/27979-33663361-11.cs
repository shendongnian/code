    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class SubmitActionToThisMethodAttribute : ActionNameSelectorAttribute
    {        
        public SubmitActionToThisMethodAttribute([CallerMemberName]string ControllerMethodName = "")
        {
            controllerMethod = ControllerMethodName;
            actionFormat = string.Concat(actionConstant, ":", controllerMethod);
        }
        const string actionConstant = "action";
        readonly string actionFormat;
        readonly string controllerMethod;
        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            var isValidName = false;
            var value = controllerContext.Controller.ValueProvider.GetValue(actionFormat);
            if (value != null)
            {
                controllerContext.Controller.ControllerContext.RouteData.Values[actionConstant] = controllerMethod;
                isValidName = true;
            }
            return isValidName;
        }
    }
