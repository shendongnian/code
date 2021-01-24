        public static int[,] ToInteger(Bitmap input)
        {
            //// We are presuming that the image is grayscale.
            //// A color image is impossible to convert to 2D.
            int Width = input.Width;
            int Height = input.Height;
            int[,] array2d = new int[Width, Height];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Color cl = input.GetPixel(x, y);
                    // image is Grayscale
                    // three elements are averaged.
                    int gray = (int)Convert.ChangeType(cl.R * 0.3 + cl.G * 0.59 + cl.B * 0.11, typeof(int));
                    array2d[x, y] = gray;
                }
            }
            return array2d;
        }
