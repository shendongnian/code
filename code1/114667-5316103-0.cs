    public static d.RectangleF ScaleRect(d.RectangleF dest, d.RectangleF src, bool keepWidth, bool keepHeight)
        {
            d.RectangleF destRect = new d.RectangleF();
            float sourceAspect = src.Width / src.Height;
            float destAspect = dest.Width / dest.Height;
            if (sourceAspect > destAspect)
            {
                // wider than high keep the width and scale the height
                destRect.Width = dest.Width;
                destRect.Height = dest.Width / sourceAspect;
                if (keepHeight)
                {
                    float resizePerc = dest.Height / destRect.Height;
                    destRect.Width = dest.Width * resizePerc;
                    destRect.Height = dest.Height;
                }
            }
            else
            {
                // higher than wide – keep the height and scale the width
                destRect.Height = dest.Height;
                destRect.Width = dest.Height * sourceAspect;
                if (keepWidth)
                {
                    float resizePerc = dest.Width / destRect.Width;
                    destRect.Width = dest.Width;
                    destRect.Height = dest.Height * resizePerc;
                }
            }
            return destRect;
        }
