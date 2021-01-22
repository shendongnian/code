        public static Bitmap Diff(Bitmap src1, Bitmap src2, int x1, int y1, int x2, int y2, int width, int height)
    {
        Bitmap diffBM = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                //Get Both Colours at the pixel point
                Color col1 = src1.GetPixel(x1 + x, y1 + y);
                Color col2 = src2.GetPixel(x2 + x, y2 + y);
                // Get the difference RGB
                int r = 0, g = 0, b = 0;
                r = Math.Abs(col1.R - col2.R);
                g = Math.Abs(col1.G - col2.G);
                b = Math.Abs(col1.B - col2.B);
                // Invert the difference average
                int dif = 255 - ((r+g+b) / 3);
                // Create new grayscale RGB colour
                Color newcol = Color.FromArgb(dif, dif, dif);
                diffBM.SetPixel(x, y, newcol);
            }
        }
        return diffBM;
    }
