    public static byte[] ResizeImageFile(byte[] imageFile, int targetSize)
    {
        using (System.Drawing.Image oldImage = System.Drawing.Image.FromStream(new MemoryStream(imageFile)))
        {
            Size newSize = CalculateDimensions(oldImage.Size, targetSize);
        using (Bitmap newImage = new Bitmap(newSize.Width, newSize.Height,  
                                                            oldImage.PixelFormat))
        {
            newImage.SetResolution(oldImage.HorizontalResolution, 
                                                       oldImage.VerticalResolution);
            using (Graphics canvas = Graphics.FromImage(newImage))
            {
                canvas.SmoothingMode = SmoothingMode.AntiAlias;
                canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), newSize));
                MemoryStream m = new MemoryStream();
                newImage.Save(m, ImageFormat.Jpeg);
                return m.GetBuffer();
            }
        }
       }
    }
