    <%@ WebHandler Language="C#" Class="DownloadHandler" %>
    
    using System;
    using System.Web;
    
    public class DownloadHandler : IHttpHandler {
        public void ProcessRequest(HttpContext context) {
            var fileName = "myfile.sql";
            var r = context.Response;
            r.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            r.ContentType = "text/plain";
            r.WriteFile(context.Server.MapPath(fileName));
        }
        public bool IsReusable { get { return false; } }
    }
