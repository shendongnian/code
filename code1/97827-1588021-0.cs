    Bitmap bitmap = new Bitmap("123712.jpg");
    float brightness = 0;
    for (int x = 0; x < bitmap.Size.Width; x++)
    {
         for (int y = 0; y < bitmap.Size.Height; y++)
         {
              brightness += bitmap.GetPixel(x, y).GetBrightness();
         }
    }
    float average = brightness / (bitmap.Size.Width + bitmap.Size.Height);
