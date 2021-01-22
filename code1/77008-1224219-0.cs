    public const int PIXEL_REGION = 60;
    public const int TRANSPARENT_DISTANCE = 60;
    public static readonly Color TRANSPARENT_COLOR = Color.White;
     
    private System.Drawing.Image ProcessImage(System.Drawing.Image image)
    {
        Bitmap result = new Bitmap(image.Width, image.Height);
        Bitmap workImage = new Bitmap(image);
        for (int x = 0; x < image.Width; x++)
        {
            for (int y = 0; y < image.Height; y++)
            {
                Color color = workImage.GetPixel(x, y);
                if (x < PIXEL_REGION || x > image.Width - PIXEL_REGION || y < PIXEL_REGION || y > image.Height - PIXEL_REGION)
                {
                    double distance = CalculateColourDistance(TRANSPARENT_COLOR, color);
                    
                    if(distance < TRANSPARENT_DISTANCE)
                    {
                        result.SetPixel(x, y, Color.Transparent);
                        continue;
                    }
                }
                result.SetPixel(x, y, color);
            }
        }
        return result;
    }
    private double CalculateColourDistance(Color c1, Color c2)
    {
        int a = c2.A - c1.A;
        int r = c2.R - c1.R;
        int g = c2.G - c1.G;
        int b = c2.B - c1.B;
        return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(r, 2) + Math.Pow(g, 2) + Math.Pow(b, 2));
    }
    
