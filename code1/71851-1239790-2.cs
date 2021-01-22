    public static class GDI
    {
        private const UInt32 SRCCOPY = 0x00CC0020;
        [DllImport("gdi32.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, UInt32 dwRop);
        public static void CopyGraphics(Graphics g, Rectangle bounds, Graphics bufferedGraphics, Point p)
        {
            IntPtr hdc1 = g.GetHdc();
            IntPtr hdc2 = bufferedGraphics.GetHdc();
            BitBlt(hdc1, bounds.X, bounds.Y, 
                bounds.Width, bounds.Height, hdc2, p.X, p.Y, SRCCOPY);
            g.ReleaseHdc(hdc1);
            bufferedGraphics.ReleaseHdc(hdc2);
        }
	}
