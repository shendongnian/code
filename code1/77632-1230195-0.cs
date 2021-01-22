    public static void doSomethingWithBitmap(Bitmap bmp)
    {
    
         for (int x = 0; x < bmp.Width; x++)
         {
              for (int y = 0; y < bmp.Height; y++)
              {
                   Color clr = bmp.GetPixel(x, y);
    
                   int red = clr.R;
                   int green = clr.G;
                   int blue = clr.B;
              }
         }
    }
