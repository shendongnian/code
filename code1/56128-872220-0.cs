        // fake data
        int[,] data = new int[100, 100];
        for (int x = 0; x < 100; x++)
            for (int y = 0; y < 100; y++)
                data[x, y] = x + y;
        Bitmap bmp = new Bitmap(100, 100, PixelFormat.Format32bppArgb);
        BitmapData bd = bmp.LockBits(new Rectangle(0, 0, 100, 100),
             ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
        unsafe
        {
            byte* root = (byte*)bd.Scan0;
            for (int y = 0; y < 100; y++)
            {
                byte* pixel = root;
                for (int x = 0; x < 100; x++)
                {
                    byte col = (byte)data[x, y];
                    pixel[0] = col;
                    pixel[1] = col;
                    pixel[2] = col;
                    pixel[3] = 255;
                    pixel += 4;
                }
                root += bd.Stride;
            }
        }
        bmp.Save("foo.bmp");
