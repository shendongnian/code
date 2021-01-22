    Bitmap atlasImage = new Bitmap(@"C:\somepicture.png");
    PixelFormat pixelFormat = atlasImage.PixelFormat;
    
    foreach (Texture t in textureList)
    {
         try
         {
               CroppedImage = new Bitmap(t.width, t.height, pixelFormat);
               // copy pixels over to avoid antialiasing or any other side effects of drawing
               // the subimages to the output image using Graphics
               for (int x = 0; x < t.width; x++)
                   for (int y = 0; y < t.height; y++)
                       CroppedImage.SetPixel(x, y, atlasImage.GetPixel(t.x + x, t.y + y));
               CroppedImage.Save(Path.Combine(workingFolder, t.name + ".png"), ImageFormat.Png);
         }
         catch (Exception ex)
         {
              // handle the exception
         }
    }
