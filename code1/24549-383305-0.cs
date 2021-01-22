    Bitmap bmp = (Bitmap)Bitmap.FromFile("image.jpg");
    for (int x = 0; x < bmp.Width; x++)
    {
        for (int y = 0; y < bmp.Height; y++)
        {
            if (bmp.GetPixel(x, y) == Color.Red)
            {
                bmp.SetPixel(x, y, Color.Blue);
            }
        }
    }
    pictureBox1.Image = bmp;
