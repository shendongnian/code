    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    public class Screenshot
    {
        class NativeMethods
        {
            // http://msdn.microsoft.com/en-us/library/ms633519(VS.85).aspx
            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
            // http://msdn.microsoft.com/en-us/library/a5ch4fda(VS.80).aspx
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }
        }
        /// <summary>
        /// Takes a screenshot of the browser.
        /// </summary>
        /// <param name="b">The browser object.</param>
        /// <param name="filename">The path to store the file.</param>
        /// <returns></returns>
        public static bool SaveScreenshot(Browser b, string filename)
        {
            bool success = false;
            IntPtr hWnd = b.hWnd;
            NativeMethods.RECT rect = new NativeMethods.RECT();
            if (NativeMethods.GetWindowRect(hWnd, ref rect))
            {
                Size size = new Size(rect.Right - rect.Left,
                                     rect.Bottom - rect.Top);
                // Get information about the screen
                using (Graphics browserGraphics = Graphics.FromHwnd(hWnd))
                // apply that info to a bitmap...
                using (Bitmap screenshot = new Bitmap(size.Width, size.Height, 
                                                      browserGraphics))
                // and create an Graphics to manipulate that bitmap.
                using (Graphics imageGraphics = Graphics.FromImage(screenshot))
                {
                    int hWndX = rect.Left;
                    int hWndY = rect.Top;
                    imageGraphics.CopyFromScreen(hWndX, hWndY, 0, 0, size);
                    screenshot.Save(filename, ImageFormat.Bmp);
                    success = true;
                }
            }
            // otherwise, fails.
            return success;
        }   
    }
