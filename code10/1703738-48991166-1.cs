            for (int i = 0; i < images.Count; i++)
            {
                ((Bitmap)images[i]).SetResolution(g.DpiX, g.DpiY);
                g.DrawImage((Bitmap)images[i], new Point(10, (i + 1) * 10 + size));
                Bitmap bmp = (Bitmap)images[i];
                ...
            }
