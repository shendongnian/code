    public class JsonResultWithStatusCode : JsonResult
    {
         private readonly HttpStatusCode statusCode;
    
         public JsonResultWithStatusCode(object data, HttpStatusCode statusCode)
         {
              Data = data;
              this.statusCode = statusCode;
         }
    
         public override void ExecuteResult(ControllerContext context)
         {
             context.RequestContext.HttpContext.Response.StatusCode = (int)statusCode;
             base.ExecuteResult(context);
         }
    }
