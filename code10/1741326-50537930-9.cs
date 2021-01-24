    <%@ WebHandler Language="C#" Class="ShowPDF" %>
    
    using System;
    using System.Web;
    using System.Web.SessionState; // Added manually.
    using System.IO; // Added manually.
    
    // You'll have to add 'IReadOnlySessionState' manually.
    public class ShowPDF : IHttpHandler, IReadOnlySessionState {
    
        public void ProcessRequest (HttpContext context)  {
            // Do your PDF proccessing here.
            context.Response.Clear();
            context.Response.ContentType = "application/pdf";
            string filePath = System.Web.HttpContext.Current.Server.MapPath(@"~\docs\sample.pdf");
            context.Response.TransmitFile(filePath);
    
            // Show the passed data from the code behind. It might be handy in the future to pass some parameters and not expose then on url, for database updating, etc.
            context.Response.Write(context.Session["myData"].ToString());
        }
    
        public bool IsReusable {
            get {
                return false;
            }
        }
    
    }
