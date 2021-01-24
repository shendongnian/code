    public class CheckAuthorization: AuthorizeAttribute
    {
        public CheckAuthorization(){
        }
       
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
        	bool _isAuthorize = false;
    
        	if(password change required)
        		httpContext.Response.Redirect("~/home/changepassword");
    
        	if (!httpContext.User.Identity.IsAuthenticated)
                return false;
    
             // Check roles 
             
             return true;
        }
    }
