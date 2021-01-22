    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "image/jpeg";
        using (Bitmap bmp = 
            (Bitmap)Bitmap.FromFile("http://internal-photoserver/bobsmith.jpg"))
        {
            bmp.Save(
                HttpContext.Current.Response.OutputStream,
                ImageFormat.Jpeg);
        }
        HttpContext.Current.Response.End();
    }
    // needs these two using statements:
    using System.Drawing;
    using System.Drawing.Imaging;
