    public class EntityNotFoundExceptionFilter : IExceptionFilter
    {
       public EntityNotFoundExceptionFilter(// some dependencies that u want to inject)
       {
           ...
       }
    
       public void OnException(ExceptionContext context)
       {
          if (!(context.Exception is EntityNotFoundException))
          {
              return;
          }
          context.ExceptionHandled = true;
          context.Result = new NotFoundObjectResult // will produce 404 response, you can also set context.HttpContext.Response.StatusCode based on your exceptions statuscode
          {
             context.Exception.Message
          }
       }
    }
