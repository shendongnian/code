    using System.Web;
    public class MyCsvDocumentHandler : IHttpHandler
    {
        public static string Data
        {
            get;
            set;
        }
        public MyCsvDocumentHandler()
        {
        }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/csv"; // Set the MIME type.
            context.Response.Write(Data); // Write the CSV data to the respone stream.
        }
        public bool IsReusable
        {
            // To enable pooling, return true here.
            // This keeps the handler in memory.
            get { return false; }
        }
    }
