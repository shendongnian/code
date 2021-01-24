    public class MyCustomFilter : ActionFilterAttribute
    {
        private MemoryStream responseBody ;
    
        public override void OnActionExecuting(ActionExecutingContext context){
            this.responseBody=new MemoryStream();
            // hijack the real stream with our own memory stream 
            context.HttpContext.Response.Body = responseBody;
        }
    
        public override void OnResultExecuted(ResultExecutedContext context)
        {
    
            responseBody.Seek(0, SeekOrigin.Begin);
    
            // read our own memory stream 
            using (StreamReader sr = new StreamReader(responseBody))
            {
                var actionResult= sr.ReadToEnd();
                Console.WriteLine(actionResult);
                // create new stream and assign it to body 
                // context.HttpContext.Response.Body = ;
            }
    
            // no ERROR on the next line!
    
            base.OnResultExecuted(context);
        }
    }
