                     Bitmap colouredBitmap = new Bitmap("fromFile");
                     int x, y;
    
                     // Loop through the images pixels to reset color.
                     for (x = 0; x < colouredBitmap.Width; x++)
                     {
                         for (y = 0; y < colouredBitmap.Height; y++)
                         {
                             Color pixelColor = colouredBitmap.GetPixel(x, y);
                             Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
                             colouredBitmap.SetPixel(x, y, newColor); // Now greyscale
                         }
                     } 
