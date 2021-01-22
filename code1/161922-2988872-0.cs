    public class FileUploader : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
           string fileName = context.Request.QueryString["FileName"];
           byte[] fileData = context.Request.BinaryRead(context.Request.ContentLength);
           string path = ...; // decide where you want to save the file
           File.WriteAllBytes(path, fileData);
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
 
