    public void WriteImage(string path, int width, int height)
    {
        Bitmap srcBmp = new Bitmap(path);
        float ratio = srcBmp.Width / srcBmp.Height;
        SizeF newSize = new SizeF(width, height * ratio);
        Bitmap target = new Bitmap((int) newSize.Width,(int) newSize.Height);
        HttpContext.Response.Clear();
        HttpContext.Response.ContentType = "image/jpeg";
        using (Graphics graphics = Graphics.FromImage(target))
        {
            graphics.CompositingQuality = CompositingQuality.HighSpeed;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.DrawImage(srcBmp, 0, 0, newSize.Width, newSize.Height);
            using (MemoryStream memoryStream = new MemoryStream()) 
            {
                target.Save(memoryStream, ImageFormat.Jpeg);
                memoryStream.WriteTo(HttpContext.Response.OutputStream);
            }
        }
        Response.End();
    }
