public class TransactionAttribute : ActionFilterAttribute
{
      public override void OnActionExecuting(ActionExecutingContext filterContext)
      {
         UnitOfWork.Start();
      }
      public override void OnActionExecuted(ActionExecutedContext filterContext)
      {
         UnitOfWork.Stop();
      }
}
