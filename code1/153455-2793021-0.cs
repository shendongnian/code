    <%@ WebHandler Language="C#" Class="PhotoHandler" %>
    
    using System;
    using System.Web;
    
    public class PhotoHandler : IHttpHandler {
        
        public void ProcessRequest (HttpContext context) {
            string photoName = context.Request.QueryString["photoName"]; 
            context.Response.ContentType = "image/jpeg";
            context.Response.WriteFile(
                String.Format(
                    @"\\internal-photoserver\shared drive\{0}.jpg", 
                    photoName));
        }
     
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
