    public class ModelStateValidationFilter : ActionFilterAttribute
    {
         public override void OnActionExecuting(ActionExecutingContext context)
         {
             // You can access it via context.ModelState
             ModelState.AddModelError("YourFieldName", "Error details...");
             base.OnActionExecuting(context);
         }
    }
