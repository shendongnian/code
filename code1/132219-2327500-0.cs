    public class AllParamsRequiredAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            var paramList = methodInfo.GetParameters().Select(p => p.Name);
            foreach (var p in paramList)
                if (controllerContext.Controller.ValueProvider.GetValue(controllerContext, p) == null) return false;
            return true;
        }
    }
