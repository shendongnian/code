    public class Download : IHttpHandler
    {
        public void ProcessRequest(System.Web.HttpContext context)
        {
            // read the file name passed in the request
            string fileid = context.Request["fileid"];
            string fileContents = GetFileFromStore(fileid);
            var response = context.Response;
            response.ContentType = "text/plain";
            response.Write(fileContents);
        }
        public bool IsReusable
        {
            get { return true; }
        }
    }
