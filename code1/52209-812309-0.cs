    class AliasedBitmapSource : BitmapSource
    {
    private Bitmap source;
    public AliasedBitmapSource(Bitmap source)
    {
    this.source = source;
    this.pixelHeight = source.Height;
    this.pixelWidth = source.Width;
    this.dpiX = source.HorizontalResolution;
    this.dpiY = source.VerticalResolution;
    }
    
    public override event EventHandler DownloadCompleted;
    public override event EventHandler<ExceptionEventArgs> DownloadFailed;
    public override event EventHandler<ExceptionEventArgs> DecodeFailed;
    
    protected override Freezable CreateInstanceCore()
    {
    throw new NotImplementedException();
    }
    
    private readonly double dpiX;
    public override double DpiX
    {
    get
    {
    return dpiX;
    }
    }
    
    private readonly double dpiY;
    public override double DpiY
    {
    get
    {
    return dpiY;
    }
    }
    
    private readonly int pixelHeight;
    public override int PixelHeight
    {
    get
    {
    return pixelHeight;
    }
    }
    
    private readonly int pixelWidth;
    public override int PixelWidth
    {
    get
    {
    return pixelWidth;
    }
    }
    
    public override System.Windows.Media.PixelFormat Format
    {
    get
    {
    return PixelFormats.Bgra32;
    }
    }
    
    public override BitmapPalette Palette
    {
    get
    {
    return null;
    }
    }
    
    public unsafe override void CopyPixels(Int32Rect sourceRect, Array pixels, int stride, int offset)
    {
    BitmapData sourceData = source.LockBits(
    sourceRect.ToRectangle(),
    ImageLockMode.ReadWrite,
    System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    
    fixed (byte* _ptr = &((byte[])pixels)[0])
    {
    byte* dstptr = _ptr;
    byte* srcptr = (byte*)sourceData.Scan0;
    
    for (int i = 0; i < pixels.Length; ++i)
    {
    *dstptr = *srcptr;
    ++dstptr;
    ++srcptr;
    }
    }
    
    source.UnlockBits(sourceData);
    }
    }
    
    public static class Extensions
    {
    public static Rectangle ToRectangle(this Int32Rect me)
    {
    return new Rectangle(
    me.X,
    me.Y,
    me.Width,
    me.Height);
    }
    
    public static Int32Rect ToInt32Rect(this Rectangle me)
    {
    return new Int32Rect(
    me.X,
    me.Y,
    me.Width,
    me.Height);
    }
    }
