    public Image Crop(string img, int width, int height, int x, int y)
    {
        try
        {
            Image image = Image.FromFile(img);
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            bmp.SetResolution(80, 60);
    
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.SmoothingMode = SmoothingMode.AntiAlias;
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
            gfx.DrawImage(image, new Rectangle(0, 0, width, height), x, y, width, height, GraphicsUnit.Pixel);
            // Dispose to free up resources
            image.Dispose();
            bmp.Dispose();
            gfx.Dispose();
    
            return bmp;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return null;
        }            
    }
