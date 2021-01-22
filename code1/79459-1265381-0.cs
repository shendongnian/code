    using System.Runtime.InteropServices;
    public class DeviceCaps
    {
        private const int PLANES = 14;
        private const int BITSPIXEL = 12;
        [DllImport("gdi32", CharSet = CharSet.Ansi, 
            SetLastError = true, ExactSpelling = true)]
        private static extern int GetDeviceCaps(int hdc, int nIndex);
        [DllImport("user32", CharSet = CharSet.Ansi, 
            SetLastError = true, ExactSpelling = true)]
        private static extern int GetDC(int hWnd);
        [DllImport("user32", CharSet = CharSet.Ansi, 
            SetLastError = true, ExactSpelling = true)]
        private static extern int ReleaseDC(int hWnd, int hdc);
        
        public short ColorDepth()
        {
            int dc = 0;
            try 
            {
                dc = GetDC(0);
                var nPlanes = GetDeviceCaps(dc, PLANES);
                var bitsPerPixel = GetDeviceCaps(dc, BITSPIXEL);
                return nPlanes * bitsPerPixel;                 
            }
            finally
            {
                if (dc != 0)
                    ReleaseDC(0, dc);
            }
        }
    }
