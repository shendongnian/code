    public static void Fill(this Texture2D t, Func<int, int, Color> perPixel)
            {
                var data = new Color[t.Height * t.Width];
                for (int y = 0; y < t.Height; y++)
                    for (int x = 0; x < t.Width; x++)
                    {
                        data[x + (y * t.Width)] = perPixel(x, y);
                    }
                t.SetData(data);
            }
