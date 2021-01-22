    <%@ WebHandler Language="C#" Class="keepalive" %>
    
    using System;
    
    public class keepalive : System.Web.IHttpHandler
    {    	
    	public void ProcessRequest (System.Web.HttpContext context) 
    	{
    		context.Response.ContentType = "text/json";
    		var thisUser = System.Web.Security.Membership.GetUser();
    		
    		if (thisUser != null)
    			context.Response.Write("[{\"User\": \"" + thisUser.UserName + "\"}]");
        }
     
        public bool IsReusable
    	{
            get { return false; }
        }
    }
