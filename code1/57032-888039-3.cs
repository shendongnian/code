    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Web;
    
    public class ImageHandler : IHttpHandler
    {
    
        public void ProcessRequest(HttpContext context)
        {
            int width = int.Parse(context.Request.QueryString["width"]);
            int height = int.Parse(context.Request.QueryString["height"]);
            
            using (Bitmap bitmap = new Bitmap(width,height)) {
    
                ...
    
                using (MemoryStream mem = new MemoryStream()) {
                    bitmap.Save(mem,ImageFormat.Png);
                    mem.Seek(0,SeekOrigin.Begin);
                    context.Response.ContentType = "image/png";
                    mem.CopyTo(context.Response.OutputStream,4096);
                    context.Response.Flush();
                }
            }
        }
    
    }
