    public class SelectorAttribute : ActionMethodSelectorAttribute
        {
            public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
            {
                int a;
                return int.TryParse((string)controllerContext.HttpContext.Request.QueryString["username"], out a);
            }
        }
