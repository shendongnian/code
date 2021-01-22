    Image BackImage = Image.FromFile(backgroundPath);
    using (Graphics g = Graphics.FromImage(BackImage))
    {
        using (ForeImage = Image.FromFile(foregroundPath))
        {   
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetColorKey(Color.FromArgb(245, 245, 245), Color.FromArgb(255, 255, 255),
                ColorAdjustType.Default);
            g.DrawImage(ForeImage, new Rectangle(0, 0, BackImage.Width, BackImage.Height),
                0, 0, BackImage.Width, BackImage.Height, GraphicsUnit.Pixel, imageAttr);
        }
    }
