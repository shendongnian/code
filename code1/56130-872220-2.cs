        // fake data
        int[,] data = new int[100, 150];
        int width = data.GetLength(0), height= data.GetLength(1);
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                data[x, y] = x + y;
        // process it into a Bitmap
        Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
        BitmapData bd = bmp.LockBits(new Rectangle(0, 0, width, height),
           ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
        unsafe {
            byte* root = (byte*)bd.Scan0;
            for (int y = 0; y < height; y++) {
                byte* pixel = root;
                for (int x = 0; x < width; x++) {
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
        bmp.UnlockBits(bd);
        bmp.Save("foo.bmp"); // or show on screen, etc
