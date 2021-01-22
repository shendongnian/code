    using System.Windows.Interop;
    using System.Windows.Media.Imaging;
    public static ImageSource AsImageSource<TColor, TDepth>(
        this Image<TColor, TDepth> image) where TColor : IColor, new()
    {
        return Imaging.CreateBitmapSourceFromHBitmap(image.Bitmap.GetHbitmap(),
                           IntPtr.Zero, Int32Rect.Empty,
                           BitmapSizeOptions.FromEmptyOptions());
    }
