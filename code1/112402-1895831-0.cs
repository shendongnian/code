    public class RedirectWithSession : IHttpHandler{
    
          public void ProcessRequest(HttpContext context){
               Response.Cookies.Add("ASP.NET_SessionID", Request.QueryString["SessionID"]);
               Response.Redirect(Request.QueryString["RedirectUrl"]);
          }
    
    }
