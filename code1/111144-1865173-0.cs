    public System.Drawing.Image LoadImagePiece(string imagePath, Rectangle desiredPortion)
    {
       using (Image img = Image.FromFile(path))
       {
           Bitmap result = new Bitmap(desiredPortion.Width, desiredPortion.Height, PixelFormat.Format24bppRgb);
           using (Graphics g = Graphics.FromImage((Image)result))
           {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(img, 0, 0, desiredPortion, GraphicsUnit.Pixel);
           }
           return result;
       }
    }
