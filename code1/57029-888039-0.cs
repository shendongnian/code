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
            bitmap.Save(mem,ImageFormat.PNG);
            
            byte[] buffer = mem.ToArray();
    
            context.Repsonse.ContentType = "image/png";
            context.Response.Write(buffer);
            context.Response.Flush();
        }
    
    }
