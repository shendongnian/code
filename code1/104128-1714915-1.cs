    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);
    private static BitmapSource LoadImage(string path)
    {
        BitmapSource source;
        using (var bmp = new Bitmap(path))
        {
            IntPtr hbmp = bmp.GetHbitmap();
            source = Imaging.CreateBitmapSourceFromHBitmap(
                hbmp,
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(hbmp);
        }
        return source;
    }
