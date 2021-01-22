    // Sample from the ASP.Net Personal Web Site Starter Kit
    public class Handler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }
        public void ProcessRequest(HttpContext context)
        {
            // Set up the response settings
            context.Response.ContentType = "image/jpeg";
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.BufferOutput = false;
            // QueryString parameters are available here:
            // context.Request.QueryString["QueryStringKey"]
            
            // You can also access the Referrer object, and log the requests here.
            
            Stream stream;
            // Read your image into the stream, either from file system or DB
            if (stream == null)
            {
                stream = PhotoManager.GetPhoto();
            }
            // Write image stream to the response stream
            const int buffersize = 1024 * 16;
            var buffer = new byte[buffersize];
            int count = stream.Read(buffer, 0, buffersize);
            while (count > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, count);
                count = stream.Read(buffer, 0, buffersize);
            }
        }
    }
