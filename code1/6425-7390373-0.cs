    /// <summary> 
    /// Converts a <see cref="System.Drawing.Bitmap"/> into a WPF <see cref="BitmapSource"/>. 
    /// </summary> 
    /// <remarks>Uses GDI to do the conversion. Hence the call to the marshalled DeleteObject. 
    /// </remarks> 
    /// <param name="source">The source bitmap.</param> 
    /// <returns>A BitmapSource</returns> 
    public static System.Windows.Media.Imaging.BitmapSource ToBitmapSource(this System.Drawing.Bitmap source)
    {
        return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(source.GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
    }
