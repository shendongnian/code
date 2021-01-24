    public class LatestErrorHandler : ActionFilterAttribute, IExceptionFilter
    {
        private const string FILE_NAME = "Exception.log";
        private const string TRACE_FILE = "TraceLog.log";
        public Type _exceptionType;
        FileStream _fileStream;
        StreamWriter _streamWriter;
        IHostingEnvironment host;
        public LatestErrorHandler(Type exceptionType)
        {
           // _fileStream = File.OpenWrite(host.ContentRootPath + "\\wale.log");
            //_streamWriter = new StreamWriter(_fileStream);
            //_fileStream.Close();
            _exceptionType = exceptionType;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            using (FileStream fs=new FileStream(TRACE_FILE, FileMode.Append, FileAccess.Write))
            {
                using (BinaryWriter rite=new BinaryWriter(fs))
                {
                    if (context.HttpContext.Response==null)
                    {
                        string con = "No log";
                        rite.Write(con);
                    }
                    else
                    {
                        Controller exValue = (Controller)context.Controller;
                        ControllerContext control = (ControllerContext)exValue.ControllerContext;
                        ///HttpMethodActionConstraint http = (HttpMethodActionConstraint)control.ActionDescriptor.ActionConstraints.;
                       
                        rite.Write(
                                     "  Date Exception Occurred" + DateTime.Now.ToString() +
                                     "  Route " 
                                     +control.RouteData.DataTokens.Values
                                     +context.RouteData.Routers
                                     //+control.ActionDescriptor.ActionConstraints+ ":"+ http.HttpMethods
                                     + context.RouteData.Values.Keys
                                     + control.ActionDescriptor.ActionName
                                     +context.ActionDescriptor.RouteValues.Values+
                                     "  Parameter"
                                     + context.ActionDescriptor.Parameters 
                                     +context.ActionDescriptor.Properties+
                                     "  Controller" 
                                     + control.ActionDescriptor.ControllerName
                                               );
                    }
                }
            }
            
        }
  
        public void OnException(ExceptionContext context)
        {
            var cont= context.Exception;
            //var contInner = context.Exception.InnerException;
            using (FileStream fs = new FileStream(FILE_NAME, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (BinaryWriter rite = new BinaryWriter(fs))
              {
                    // context.Result actionResult = new context.Result();
                    if (context.HttpContext.Response == null)
                    {
                        string con = "no errroer  ";
                        rite.Write(con);
                    }
                    else
                    {
                        rite.Write(
                            "Date Exception Occurred" + DateTime.Now.ToString() +
                            " Exceptions" + "Message: " + cont.Message +
                            " InnerException" + cont.InnerException +
                            " StackTrace" + cont.StackTrace+
                            "Response" + context.HttpContext.Response.StatusCode
                        );
                    }
                }
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            
            base.OnActionExecuted(context);
            var cont = context.Exception;
            //var contInner = context.Exception.InnerException;
            using (FileStream fs = new FileStream(FILE_NAME, FileMode.Append, FileAccess.Write))
            {
                using (BinaryWriter rite=new BinaryWriter(fs))
                {
                    // context.Result actionResult = new context.Result();
                   var type =  context.Result.GetType().Name;   //context.Result
                    if(type == "BadRequestObjectResult" )
                    {
                        BadRequestObjectResult cont2 = (BadRequestObjectResult)context.Result;
                        Exception exValue = (Exception) cont2.Value;
                        if (exValue.InnerException==null)
                        {
                            rite.Write(
                                  "\n  Date Exception Occurred  " + DateTime.Now.ToString() +
                                  "\n  Exceptions" + "Message: " + cont2.Value +
                                 // "\n  InnerException  " + exValue.InnerException +
                                  "\n  Message    " + exValue.Message +
                                  "\n  StackTrace  " + exValue.StackTrace
                           //"Response" + context.HttpContext.Response.StatusCode
                           );
                        }
                        else
                        {
                            rite.Write(
                                   "\n  Date Exception Occurred  " + DateTime.Now.ToString() +
                                   "\n  Exceptions" + "Message: " + cont2.Value +
                                   "\n  InnerException  " + exValue.InnerException +
                                   "\n  Message    " + exValue.Message +
                                   "\n  StackTrace  " + exValue.StackTrace
                            //"Response" + context.HttpContext.Response.StatusCode
                            );
                        }
                       
                    }
                                   
                       
                   
                    else
                    {
                        // log details without error.
                        
                    }
                }
                
            }
            
        }
    }
