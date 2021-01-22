    public class DeleteFileAttribute : ActionFilterAttribute 
    { 
        public override void OnResultExecuted(ResultExecutedContext filterContext) 
        { 
            filterContext.HttpContext.Response.Flush();
            // Delete file 
        } 
    } 
