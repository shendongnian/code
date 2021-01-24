    if (File.Exists("chunk," + (px - 1) + "," + (py) + ".jpeg"))
        {
            Bitmap source = new Bitmap("chunk," + (px - 1) + "," + (py) + ".jpeg");
            for (int y = 0; y < 256; y++)
            {
                seed.SetPixel(0, y, Color.FromArgb(255, source.GetPixel(255, y).R, source.GetPixel(255, y).G, source.GetPixel(255, y).B));
            }
            source.Dispose();
        }
        if (File.Exists("chunk," + (px + 1) + "," + (py) + ".jpeg"))
        {
            Bitmap source = new Bitmap("chunk," + (px + 1) + "," + (py) + ".jpeg");
            for (int y = 0; y < 256; y++)
            {
                seed.SetPixel(255, y, Color.FromArgb(255, source.GetPixel(0, y).R, source.GetPixel(0, y).G, source.GetPixel(0, y).B));
            }
            source.Dispose();
        }
        if (File.Exists("chunk," + (px) + "," + (py - 1) + ".jpeg"))
        {
            Bitmap source = new Bitmap("chunk," + (px) + "," + (py - 1) + ".jpeg");
            for (int x = 0; x < 256; x++)
            {
                seed.SetPixel(x, 0, Color.FromArgb(255, source.GetPixel(x, 255).R, source.GetPixel(x, 255).G, source.GetPixel(x, 255).B));
            }
            source.Dispose();
        }
        if (File.Exists("chunk," + (px) + "," + (py + 1) + ".jpeg"))
        {
            Bitmap source = new Bitmap("chunk," + (px) + "," + (py + 1) + ".jpeg");
            for (int x = 0; x < 256; x++)
            {
                seed.SetPixel(x, 255, Color.FromArgb(255, source.GetPixel(x, 0).R, source.GetPixel(x, 0).G, source.GetPixel(x, 0).B));
            }
            source.Dispose();
        }
