    using System;
    using System.Web;
    using System.Linq;
    
    public class img_upload : IHttpHandler {
    
        public void ProcessRequest (HttpContext context) {
            string[] strBytes = ((string)context.Request.Form["bytes"]).Split(',');
            byte[] bytes = strBytes.Select(b => Convert.ToByte(b)).ToArray();
            string fileName = context.Server.MapPath("~/misc/img/" + (string)context.Request.Form["fn"]); //make sure the process has write permission
            System.IO.FileStream fs = null;
            if (context.Request.Form["chunk"] == "0")//first chunk
            {
                fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
            }
            else
            {
                fs = new System.IO.FileStream(fileName, System.IO.FileMode.Append);
            }
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
            context.Response.ContentType = "text/plain"; //or whatever
            context.Response.Write("OK");//or whatever
        }
    
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
