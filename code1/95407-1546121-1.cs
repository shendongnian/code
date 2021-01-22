    // at class level
    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);
    // your code
    using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1000, 1000)) 
    {
        IntPtr hBitmap = bmp.GetHbitmap(); 
        try 
        {
            var source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
        }
        finally 
        {
            DeleteObject(hBitmap)
        }
    }
