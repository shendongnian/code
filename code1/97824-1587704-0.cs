    Bitmap bitmap = // the bitmap
    var colors = new List<Color>();
    for (int x = 0; x < bitmap.Size.Width; x++)
    {
        for (int y = 0; y < bitmap.Size.Height; y++)
        {
            colors.Add(bitmap.GetPixel(x, y));
        }
    }
    
    float imageBrightness = colors.Average(color => color.GetBrightness());
