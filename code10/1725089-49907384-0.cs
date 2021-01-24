    public class PerUserErrorDetailExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var exResult = context.Result as ExceptionResult;
            if (!context.CatchBlock.IsTopLevel || exResult == null)
                return;
            var identity = context.RequestContext.Principal as ClaimsPrincipal;
            var showErrorDetail = identity != null
                                  && identity.Identity.IsAuthenticated
                                  && identity.IsInRole("IT");
            context.Result = new ExceptionResult(
                exResult.Exception,
                showErrorDetail,
                exResult.ContentNegotiator,
                exResult.Request,
                exResult.Formatters);
        }
    }
