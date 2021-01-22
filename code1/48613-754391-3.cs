    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.IO;
    
    BitmapSource Resize(BitmapSource original,
                        double originalScale,
                        double newScale) {
        double s = newScale / originalScale;
        return new TransformedBitmap(original, new ScaleTransform(s, s));
    }
    void OutputAsJpeg(BitmapSource src, Stream out) {
        var encoder = new JpegBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(src));
        encoder.Save(out);
    }
    // Load up your bitmap from the file system or whatever,
    // then dump it out to a smaller version and a thumbnail.
    // Assumes thumbnails have a max dimension of 64
    BitmapSource big = new BitmapImage(new Uri("BigPage0.png",
                                               UriKind. RelativeOrAbsolute));
    double bigSize = Math.Max(big.PixelWidth, big.PixelHeight);
    OutputAsJpeg(Resize(big, 300.0, 72.0), new FileStream("ScreenView.jpg"));
    OutputAsJpeg(Resize(big, bigSize, 64.0), new FileStream("Thumbnail.jpg"));
    
