    // at class level;
    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);    // https://stackoverflow.com/a/1546121/194717
    /// <summary> 
    /// Converts a <see cref="System.Drawing.Bitmap"/> into a WPF <see cref="BitmapSource"/>. 
    /// </summary> 
    /// <remarks>Uses GDI to do the conversion. Hence the call to the marshalled DeleteObject. 
    /// </remarks> 
    /// <param name="source">The source bitmap.</param> 
    /// <returns>A BitmapSource</returns> 
    public static System.Windows.Media.Imaging.BitmapSource ToBitmapSource(this System.Drawing.Bitmap source)
    {
        var hBitmap = source.GetHbitmap();
        var result = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, System.Windows.Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
        
        DeleteObject(hBitmap);
        return result;
    }
