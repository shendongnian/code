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
            Bitmap bitmap = new Bitmap(width,height);
    
            ...
    
            MemoryStream mem = new MemoryStream();
            bitmap.Save(mem,ImageFormat.Png);
            
            byte[] buffer = mem.ToArray();
    
            context.Response.ContentType = "image/png";
            context.Response.BinaryWrite(buffer);
            context.Response.Flush();
        }
    
    }
