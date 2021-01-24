    public class ResponseCodeAttribute : ResultFilterAttribute
    {
        //Public property to enable reflection, inspection
        public int StatusCode {get;}
        public ResponseCodeAttribute(int statusCode)=>StatusCode=statusCode;
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCode;
        }
    }
