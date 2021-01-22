    using System.Drawing;
    using System.Drawing.Imaging;
    public class MyHandler : IHttpHandler {
    
      public void ProcessRequest(HttpContext context) {
    
        Image img = Crop(...); // this is your crop function
        // set MIME type
        context.Response.ContentType = "image/jpeg";
        // write to response stream
        img.Save(context.Response.OutputStream, ImageFormat.Jpeg);
      }
    }
