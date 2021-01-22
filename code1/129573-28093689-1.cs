    Bitmap bt = new Bitmap("imageFilePath");
    for (int y = 0; y < bt.Height; y++)
    {
        for (int x = 0; x < bt.Width; x++)
        {
            Color c = bt.GetPixel(x, y);
    
            int r = c.R;
            int g = c.G;
            int b = c.B;
            int avg = (r + g + b) / 3;
            bt.SetPixel(x, y, Color.FromArgb(avg,avg,avg));
        }   
    }
    bt.Save("d:\\out.bmp");
