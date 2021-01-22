    public class InformationHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            // Select the assembly that contains the web service classes
            var assemblyThatContainsTheWebService = Assembly.GetExecutingAssembly();
            // Select all types in this assembly deriving from WebService
            var webServiceTypes = 
                from type in assemblyThatContainsTheWebService.GetTypes()
                where type.BaseType == typeof(WebService)
                select type;
            context.Response.ContentType = "text/plain";
            foreach (var type in webServiceTypes)
            {
                context.Response.Write(string.Format("Methods for web service {0}:{1}", type, Environment.NewLine));
                // Select all methods marked with the WebMethodAttribute
                var methods = 
                    from method in type.GetMethods()
                    where method.GetCustomAttributes(typeof(WebMethodAttribute), false).Count() > 0
                    select method;
                foreach (var method in methods)
	            {
                    context.Response.Write(method);
	            }
                context.Response.Write(Environment.NewLine);
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
