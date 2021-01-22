    public class myPhototHandler: IHttpHandler
    {    
        
        public bool IsReusable {
            get { return true; }
        }
        
        public void ProcessRequest(System.Web.HttpContext context)
        {
            
            	if (Context.User.Identity.IsAuthenticated) {
    	            var filename = context.Request.QueryString("f") ?? String.Empty;
    	            string completePath = context.Server.MapPath(string.Format("~/App_Data/Photos/{0}", path));
    	            context.Response.ContentType = "image/jpeg";
    	            context.Response.WriteFile(completePath);             
                }
           
        }
        
    }
