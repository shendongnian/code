     public class ImageHandler : IHttpHandler
      {
        public bool IsReusable
        {
          get
          {
            return true;
          }
        }
     
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = MimeTypeConstants.JPG;
            context.Response.Clear();
            context.Response.BinaryWrite(GenerateImage());
            context.Response.End();
        }
      }
