    public class TimeImageHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Bitmap bitmap = GetImageForTime(DateTime.Now);
            context.Response.ContentType = "image/jpeg";
            bitmap.Save(context.Response.OutputStream, ImageFormat.Jpeg);
        }
        public bool IsReusable { get { return false; } }
    }
