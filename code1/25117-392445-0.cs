        private Bitmap createImage(int width, int height, byte[] image)
        {
            int index = 0;
            byte r, g, b;
            Bitmap bmp = new Bitmap(width, height);
            for (y as int = 0; y &lt; height; y++)
            {                
                for (x as int = 0; x &lt; width; x++)
                {
                    b = image[y * width + index];
                    g = image[y * width + index + 1];
                    r = image[y * width + index + 2];
                    bmp.SetPixel(x, y, Color.FromArgb(255, r, g, b));
                    index += 3;
                }                
            }
            return bmp;
        }
