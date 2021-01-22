    public static Bitmap ResizeImage(Bitmap bmp, int width, int height, 
                                     InterpolationMode mode = InterpolationMode.HighQualityBicubic)                                         
    {
        Bitmap bmpOut = null;
            
        try
        {                                
            decimal ratio;
            int newWidth = 0;
            int newHeight = 0;
            // If the image is smaller than a thumbnail just return original size
            if (bmp.Width < width && bmp.Height < height)
            {
                newWidth = bmp.Width;
                newHeight = bmp.Height;
            }
            else
            {
                if (bmp.Width == bmp.Height)
                {
                    if (height > width)
                    {
                        newHeight = height;
                        newWidth = height;
                    }
                    else
                    {
                        newHeight = width;
                        newWidth = width;                         
                    }
                }
                else if (bmp.Width >= bmp.Height)
                {
                    ratio = (decimal) width/bmp.Width;
                    newWidth = width;
                    decimal lnTemp = bmp.Height*ratio;
                    newHeight = (int) lnTemp;
                }
                else
                {
                    ratio = (decimal) height/bmp.Height;
                    newHeight = height;
                    decimal lnTemp = bmp.Width*ratio;
                    newWidth = (int) lnTemp;
                }
            }
            //bmpOut = new Bitmap(bmp, new Size( newWidth, newHeight));                     
            bmpOut = new Bitmap(newWidth, newHeight);                
            bmpOut.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);
            Graphics g = Graphics.FromImage(bmpOut);
            g.InterpolationMode = mode;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.FillRectangle(Brushes.White, 0, 0, newWidth, newHeight);
            g.DrawImage(bmp, 0, 0, newWidth, newHeight);                
        }
        catch
        {
            return null;
        }
        return bmpOut;
    }
