    // For fast access to pixels        
    public static unsafe byte[] BitmapToByteArray(Bitmap bitmap) { 
        BitmapData bmd = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly,
                                         PixelFormat.Format32bppArgb);
        byte[] bytes = new byte[bmd.Height * bmd.Stride];
        byte* pnt = (byte*) bmd.Scan0;
        Marshal.Copy((IntPtr) pnt, bytes, 0, bmd.Height * bmd.Stride);
        bitmap.UnlockBits(bmd);
        return bytes;
    }
    public bool IsDark(Bitmap bitmap, byte tolerance, double darkProcent) {
        byte[] bytes = BitmapToByteArray(bitmap);
        int count = 0, all = bitmap.Width * bitmap.Height;
        for (int i = 0; i < bytes.Length; i += 4) {
            byte r = bytes[i + 2], g = bytes[i + 1], b = bytes[i];
            byte brightness = (byte) Math.Round((0.299 * r + 0.5876 * g + 0.114 * b));
            if (brightness <= tolerance)
                count++;
        }
        return (1d * count / all) <= darkProcent;
    }
    public void Run(Bitmap bitmap) { // Example of use
        // some code
        bool dark = IsDark(bitmap, 40, 0.9); 
        // some code
    }
