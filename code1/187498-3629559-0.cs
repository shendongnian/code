    <%@ WebHandler Language="C#" Class="Handler" %>
    
    using System;
    using System.Web;
    
    public class Handler : IHttpHandler
    {
        // We'll use a static var as our "database".
        // Feel free to add real database calls to the increment
        // and decrement actions below.
        static int TheNumber = 0;
    
        public void ProcessRequest(HttpContext context)
        {       
            string action = context.Request.QueryString["action"];
            if (!string.IsNullOrEmpty(action))
            {
                if (action == "increment")
                    TheNumber++;   //database update and fetch goes here
                else if (action == "decrement")
                    TheNumber--;   //database update and fetch goes here           
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(TheNumber);
        }
    
        public bool IsReusable { get { return false; } }
    }
