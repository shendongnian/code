    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "image/jpeg";
        byte[] bytes = File.ReadAllBytes(
            @"\\internal-photoserver\shared drive\bobsmith.jpg");
        HttpContext.Current.Response.OutputStream.Write(bytes, 0, bytes.Length);
        HttpContext.Current.Response.End();
    }
    // need this using statement:
    using System.IO;
