    public static class ControlExtensions
    {        
        [DllImport("coredll.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("coredll.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("coredll.dll")]
        private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, 
                                          int nWidth, int nHeight, IntPtr hdcSrc, 
                                          int nXSrc, int nYSrc, uint dwRop);
        private const uint SRCCOPY = 0xCC0020;
        public static void DrawToBitmap(this Control control, Bitmap bitmap, 
                                        Rectangle targetBounds)
        {
            var width = Math.Min(control.Width, targetBounds.Width);
            var height = Math.Min(control.Height, targetBounds.Height);
                
            var hdcControl = GetWindowDC(control.Handle);
            if (hdcControl == IntPtr.Zero)
            {
                throw new InvalidOperationException(
                    "Could not get a device context for the control.");
            }
            try
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    var hdc = graphics.GetHdc();
                    try
                    {
                        BitBlt(hdc, targetBounds.Left, targetBounds.Top, 
                               width, height, hdcControl, 0, 0, SRCCOPY);
                    }
                    finally
                    {
                        graphics.ReleaseHdc(hdc);
                    }
                }
            }
            finally
            {
                ReleaseDC(control.Handle, hdcControl);
            }
        }
    }
