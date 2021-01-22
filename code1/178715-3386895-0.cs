    //your http-handler
    public class DownloadHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string fileName = context.Request.QueryString["filename"].ToString();
            string filePath = "path of the file on disk"; //you know where your files are
            FileInfo file = new System.IO.FileInfo(filePath);
            if (file.Exists)
            {
                try
                {
                    //increment this file download count into database here.
                }
                catch (Exception)
                {
                    //handle the situation gracefully.
                }
                //return the file
                context.Response.Clear();
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                context.Response.AddHeader("Content-Length", file.Length.ToString());
                context.Response.ContentType = "application/octet-stream";
                context.Response.WriteFile(file.FullName);
                context.ApplicationInstance.CompleteRequest();
                context.Response.End();
            }
        }
        public bool IsReusable
        {
            get { return true; }
        }
    }  
