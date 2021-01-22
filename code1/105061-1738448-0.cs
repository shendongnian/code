        public static Bitmap Capture(IntPtr hwnd)
        {
            IntPtr hDC = GetDC(hwnd);
            if (hDC != IntPtr.Zero)
            {
                Rectangle rect = GetWindowRectangle(hwnd);
                Bitmap bmp = new Bitmap(rect.Width, rect.Height);
                using (Graphics destGraphics = Graphics.FromImage(bmp))
                {
                    BitBlt(
                        destGraphics.GetHdc(),
                        0,
                        0,
                        rect.Width,
                        rect.Height,
                        hDC,
                        0,
                        0,
                        TernaryRasterOperations.SRCCOPY);
                }
                return bmp;
            }
            return null;
        }
