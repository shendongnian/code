                 Bitmap c = new Bitmap("fromFile");
                 Bitmap d;
                 int x, y;
                 // Loop through the images pixels to reset color.
                 for (x = 0; x < c.Width; x++)
                 {
                     for (y = 0; y < c.Height; y++)
                     {
                         Color pixelColor = c.GetPixel(x, y);
                         Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
                         c.SetPixel(x, y, newColor); // Now greyscale
                     }
                 }
                d = c;   // d is grayscale version of c  
