    Bitmap image;
    
    for (int x = 0; x < image.Width; x++)
    {
        for (int y = 0; y < image.Height; y++)
        {
            if (image.GetPixel(x, y) != Color.Transparent)
            {
                image.SetPixel(x, y, Color.White);
            }
        }
    }
