    class ImageHandling
    {
        public static Rectangle GetScaledRectangle(Image img, Rectangle thumbRect)
        {
            if (img.Width < thumbRect.Width && img.Height < thumbRect.Height)
                return new Rectangle(thumbRect.X + ((thumbRect.Width - img.Width) / 2), thumbRect.Y + ((thumbRect.Height - img.Height) / 2), img.Width, img.Height);
            int sourceWidth = img.Width;
            int sourceHeight = img.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            nPercentW = ((float)thumbRect.Width / (float)sourceWidth);
            nPercentH = ((float)thumbRect.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            if (destWidth.Equals(0))
                destWidth = 1;
            if (destHeight.Equals(0))
                destHeight = 1;
            Rectangle retRect = new Rectangle(thumbRect.X, thumbRect.Y, destWidth, destHeight);
            if (retRect.Height < thumbRect.Height)
                retRect.Y = retRect.Y + Convert.ToInt32(((float)thumbRect.Height - (float)retRect.Height) / (float)2);
            if (retRect.Width < thumbRect.Width)
                retRect.X = retRect.X + Convert.ToInt32(((float)thumbRect.Width - (float)retRect.Width) / (float)2);
            return retRect;
        }
        public static Image GetResizedImage(Image img, Rectangle rect)
        {
            Bitmap b = new Bitmap(rect.Width, rect.Height);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(img, 0, 0, rect.Width, rect.Height);
            g.Dispose();
            try
            {
                return (Image)b.Clone();
            }
            finally
            {
                b.Dispose();
                b = null;
                g = null;
            }
        }
    }
