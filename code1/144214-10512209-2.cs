     internal class FormCookieServiceAuthorizationManager : ServiceAuthorizationManager
     {
        public override bool CheckAccess(OperationContext operationContext)
        {
           Thread.CurrentPrincipal = HttpContext.Current.User;
           return base.CheckAccess(operationContext);
        }
     }
