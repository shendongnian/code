    using (Bitmap tempImage = new Bitmap(pageToScan.FullPath))    
    {           
        if (tempImage.PixelFormat != System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        {
            Rectangle r = new Rectangle(0, 0, tempImage.Width, tempImage.Height);
            RecognizeBitmap(pageToScan, tempImage.Clone(r, PixelFormat.Format24bppRgb);          
        }
        else                  
        {
            RecognizeBitmap(pageToScan, tempImage);    
        }
    }
