    public class ImagingBitmapInfo
    {
        private ImageFlags flags;
        public ImagingBitmapInfo()
        {
            this.flags = ImageFlags.None;
            this.BitmapData = new BitmapDataInfo();
        }
        public BitmapDataInfo BitmapData  { get; set; }
        public ImageFormat ImageFormat { get; set; }
        public string ImageType { get; set; }
        public string MimeType { get; set; }
        public SizeF ImageSize { get; set; }
        public SizeF Dpi { get; set; }
        public Size PixelSize { get; set; }
        public int PixelFormatSize { get; set; }
        public int BitsPerPixel { get; set; }
        public PixelFormat PixelFormat { get; set; }
        public bool HasPalette { get; set; }
        public ColorPalette Palette { get; set; }
        public bool HasAnimation { get; set; }
        public ImageFlags Flags { 
            get { return this.flags; } 
            set { this.BitmapData.SetValues(value);
                    this.flags = value; } 
        }
        public bool IsGrayScale()
        { return CheckIfGrayScale(false); }
        public bool IsGrayScale(bool DeepScan)
        { return CheckIfGrayScale(DeepScan); }
        private bool CheckIfGrayScale(bool DeepScan)
        {
            bool result = false;
            if ((this.BitmapData.ColorSpaceGRAY == true ) || 
                (this.PixelFormat == PixelFormat.Format16bppGrayScale)) 
                result = true;
            else if (this.PixelFormat == PixelFormat.Format8bppIndexed || 
                        this.PixelFormat == PixelFormat.Format4bppIndexed || 
                        this.PixelFormat == PixelFormat.Format1bppIndexed)
                    DeepScan = true;
            if (DeepScan & this.Palette != null)
            {
                List<Color> IndexedColors = this.Palette.Entries.ToList();
                result = IndexedColors.All(rgb => (rgb.R == rgb.G && rgb.G == rgb.B && rgb.B == rgb.R));
            }
            return result;
        }
        public class BitmapDataInfo
        {
            public bool HasFlags { get; private set; }
            public bool HasAlpha { get; private set; }
            public bool IsTranslucent { get; private set; }
            public bool IsScalable { get; private set; }
            public bool IsPartiallyScalable { get; private set; }
            public bool ColorSpaceRGB { get; private set; }
            public bool ColorSpaceCMYK { get; private set; }
            public bool ColorSpaceGRAY { get; private set; }
            public bool ColorSpaceYCBCR { get; private set; }
            public bool ColorSpaceYCCK { get; private set; }
            public bool HasRealDPI { get; private set; }
            public bool HasRealPixelSize { get; private set; }
            internal void SetValues(ImageFlags Flags)
            {
                this.HasFlags = (Flags > 0);
                if (Flags > 0)
                {
                    this.HasAlpha = ((Flags & ImageFlags.HasAlpha) > 0);
                    this.HasRealDPI = ((Flags & ImageFlags.HasRealDpi) > 0);
                    this.HasRealPixelSize = ((Flags & ImageFlags.HasRealPixelSize) > 0);
                    this.IsTranslucent = ((Flags & ImageFlags.HasTranslucent) > 0);
                    this.IsPartiallyScalable = ((Flags & ImageFlags.PartiallyScalable) > 0);
                    this.IsScalable = ((Flags & ImageFlags.Scalable) > 0);
                    this.ColorSpaceCMYK = ((Flags & ImageFlags.ColorSpaceCmyk) > 0);
                    this.ColorSpaceGRAY = ((Flags & ImageFlags.ColorSpaceGray) > 0);
                    this.ColorSpaceRGB = ((Flags & ImageFlags.ColorSpaceRgb) > 0);
                    this.ColorSpaceYCBCR = ((Flags & ImageFlags.ColorSpaceYcbcr) > 0);
                    this.ColorSpaceYCCK = ((Flags & ImageFlags.ColorSpaceYcck) > 0);
                }
            }
        }
    }
    public static ImagingBitmapInfo BitmapPixelFormat(string FileName)
    {
        using (FileStream stream = File.Open(FileName, FileMode.Open, FileAccess.Read, FileShare.None))
        {
            return BitmapPixelFormat(stream);
        }
    }
    public static ImagingBitmapInfo BitmapPixelFormat(Stream stream)
    {
        ImagingBitmapInfo imageInfo = new ImagingBitmapInfo();
        Image image = Image.FromStream(stream);
        imageInfo.PixelFormat = image.PixelFormat;
        imageInfo.ImageSize = image.PhysicalDimension;
        imageInfo.HasPalette = (image.Palette != null) ? true : false;
        if (image.FrameDimensionsList.Length > 1)
            imageInfo.HasAnimation = (image.GetFrameCount(FrameDimension.Page)) > 1 ? true : false;
        imageInfo.Palette = image.Palette;
        imageInfo.Dpi = new SizeF(image.HorizontalResolution, image.VerticalResolution);
        imageInfo.Flags = (ImageFlags)image.Flags;
        imageInfo.PixelSize = image.Size;
        imageInfo.ImageFormat = image.RawFormat;
        imageInfo.PixelFormatSize = Image.GetPixelFormatSize(image.PixelFormat);
        ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders()
                                                .FirstOrDefault(enc => 
                                                    enc.FormatID == image.RawFormat.Guid);
        imageInfo.ImageType = codec.FilenameExtension.ToLowerInvariant();
        imageInfo.MimeType = codec.MimeType;
        return imageInfo;
    }
