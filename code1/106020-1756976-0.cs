    using System.Drawing;
    ...
    public static ImageSource Capture(IWin32Window w)
    {
        IntPtr hwnd = new WindowInteropHelper(w).Handle;
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
            ImageSource img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                bmp.GetHBitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            return img;
        }
        return null;
    }
