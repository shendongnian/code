    private Point GetLocation()
            {
                Img = new Bitmap("Screenshot.png");
                Color pixelColor;
    
                for (int y = 0; y < Img.Height; y++)
                {
                    for (int x = 0; x < Img.Width; x++)
                    {
                        pixelColor = Img.GetPixel(x, y);
                        if (pixelColor.R == 84 && pixelColor.G == 96 && pixelColor.B == 103)
                        {
                            MessageBox.Show($"Location is Y:{y.ToString()} X:{x.ToString()}");
                            Point p = new Point(x, y);
                            return p;
                        }
                    }
                }
