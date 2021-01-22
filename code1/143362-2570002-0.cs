        bool ContainsTransparent(Bitmap image)
        {
            bool transparency = false;
            for (int y = 0; y < image.Height; ++y)
            {
                for (int x = 0; x < image.Width; ++x)
                {
                    if (image.GetPixel(x, y).A != 255)
                    {
                        transparency = true;
                    }
                }
            }
            return transparency;
        }
