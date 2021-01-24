    public class JsonHttpStatusResult : JsonResult
    {
        private readonly HttpStatusCode _httpStatus;
        public JsonHttpStatusResult(object data, HttpStatusCode httpStatus)
        {
            Data = data;
            _httpStatus = httpStatus;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.StatusCode = (int)_httpStatus;
            base.ExecuteResult(context);
        }
    }
Now you can use it like a normal Jsonresult in non-error conditions, and in error conditions, it can be:
