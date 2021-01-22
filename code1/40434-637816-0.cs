        using (Image i = Image.FromFile(HttpContext.Current.Server.MapPath(fileName)))
        {
            float imageWidth = i.PhysicalDimension.Width;
            float imageHeight = i.PhysicalDimension.Height;
            float percentage = maxWidth / imageWidth;
            float newWidth = imageWidth * percentage;
            float newHeight = imageHeight * percentage;
            if (newHeight > maxHeight)
            {
                percentage = maxHeight / newHeight;
                newWidth = newWidth * percentage;
                newHeight = newHeight * percentage;
            }
            using (Bitmap b = new Bitmap((int)newWidth, (int)newHeight))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g.DrawImage(i, new Rectangle(0, 0, b.Width, b.Height));
                    if (effect == "new")
                    {
                        using (Image j = Image.FromFile(HttpContext.Current.Server.MapPath("/ImageEffects/") + "new.png", true))
                        {
                            g.DrawImage(j, new Rectangle(0, 0, 60, 60));
                        }
                    }
                    Image newImage = Image.FromHbitmap(b.GetHbitmap());
                    return newImage;
                }
            }
        }
    }
