    // just a marker attribute with no special logic
    public sealed class NoTransactionAttribute : Attribute { }
    
    public class TransactionAttribute : ActionFilterAttribute {
        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            if (filterContext.ActionDescriptor.IsDefined(typeof(NoTransactionAttribute), true /* inherit */)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(NoTransactionAttribute), true /* inherit */) {
                    return; // should skip logic
            }
    
            // perform your logic here
        }
    }
