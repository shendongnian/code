    public class AuditAttribute : ActionFilterAttribute
    {
       public override void OnActionExecuting(ActionExecutingContext context)
       {
           var actionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
           var controllerName = actionDescriptor.ControllerName;
           var actionName = actionDescriptor.ActionName;
           var parameters = actionDescriptor.Parameters;
           var fullName = actionDescriptor.DisplayName;
       }
    }
