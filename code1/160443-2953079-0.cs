    // inImage is your original
    Bitmap outImage = new Bitmap(newWid, newHei);
    Graphics gfx = Graphics.FromImage(outImage);
    gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
    gfx.DrawImage(inImage,
       new Rectangle(0, 0, newWid, new Hei),
       new Rectangle(0, 0, inImage.Width, inImage.Height),
       GraphicsUnit.Pixel);
