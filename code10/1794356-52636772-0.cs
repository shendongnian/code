    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var ex = context.Exception;
            if (ex == null) return;
            context.Result = new JsonResult(ex);
        }
    }
