    using (Bitmap background = (Bitmap)Bitmap.FromFile(backgroundPath))
    {
         using (Bitmap foreground = (Bitmap)Bitmap.FromFile(foregroundPath))
         {
              // check if heights and widths are the same
              if (background.Height == foreground.Height & background.Width == foreground.Width)
              {
                   using (Bitmap mergedImage = new Bitmap(background.Width, background.Height))
                   {
                        for (int x = 0; x < mergedImage.Width; x++)
                        {
                             for (int y = 0; y < mergedImage.Height; y++)
                             {
                                  Color backgroundPixel = background.GetPixel(x, y);
                                  Color foregroundPixel = foreground.GetPixel(x, y);
                                  Color mergedPixel = Color.FromArgb(backgroundPixel.ToArgb() & foregroundPixel.ToArgb());
                                  mergedImage.SetPixel(x, y, mergedPixel);
                              }
                        }
                        mergedImage.Save("filepath");
                   }
    
              }
         }
    }
