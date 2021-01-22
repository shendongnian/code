    namespace MyProject
    {
        public class ImageHandler : IHttpHandler
        {
            public virtual void ProcessRequest(HttpContext context)
            {
                // 1. Get querystring parameter
                // 2. Check if resized image is in cache
                // 3. If not, create it and cache to disk
                // 5. Send the image
                // Example Below
                // -------------
                // Get ID from querystring
                string id = context.Request.QueryString.Get("ImageId");
                // Construct path to cached thumbnail file
                string path = context.Server.MapPath("~/ImageCache/" + id + ".jpg");
                // Create the file if it doesn't exist already
                if (!File.Exists(path))
                    CreateThumbnailImage(id);
                // Set content-type, content-length, etc headers
                // Send the file
                Response.TransmitFile(path);
            }
            public virtual bool IsReusable
            {
                get { return true; }
            }
        }
    }
