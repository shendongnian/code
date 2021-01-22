    public static Color getDominantColor(Bitmap bmp)
 
    {
         //Used for tally
         int r = 0;
         int g = 0;
         int b = 0;
    
         int total = 0;
    
         for (int x = 0; x < bmp.Width; x++)
         {
              for (int y = 0; y < bmp.Height; y++)
              {
                   Color clr = bmp.GetPixel(x, y);
    
                   r += clr.R;
                   g += clr.G;
                   b += clr.B;
    
                   total++;
              }
         }
    
         //Calculate average
         r /= total;
         g /= total;
         b /= total;
    
         return Color.FromArgb(r, g, b);
    }
