    Bitmap objImage = new Bitmap("basePngPicturePath");
    Bitmap objSmallImage = new Bitmap("smallPngPicturePath");
    using (Graphics g = Graphics.FromImage(objImage))
    {
        g.DrawImage(...); // there are 30-some overloads of DrawImage, but 
            // basically you use objSmallImage as the source, 
            // plus various ways of telling the method
            // where to draw the smaller image.
    }
    objImage.Save(Response.OutputStream, ImageFormat.Jpeg);
    objImage.Dispose();
    objSmallImage.Dispose();
