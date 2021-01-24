    using (Bitmap origBitmap = new Bitmap("my_picture.jpg"))
    {
        using (Bitmap outputImage = new Bitmap(1024, 768, origBitmap.PixelFormat))
        {
            outputImage.SetResolution(origBitmap.HorizontalResolution, origBitmap.VerticalResolution);
            using (Graphics g = Graphics.FromImage(outputImage))
            {
                g.Clear(Color.Black);
                g.CompositingMode = CompositingMode.SourceCopy;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(origBitmap, newWidth, newHeight);
                context.Response.ContentType = "image/jpeg";
                outputImage.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            }
        }
    }
