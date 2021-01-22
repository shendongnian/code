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
    // then dump it out to a WebResponse or to another file.
    BitmapSource big = new BitmapImage(new Uri("BigPage0.png",
                                               UriKind. RelativeOrAbsolute));
    Stream output = /* ... */;
    OutputAsJpeg(Resize(big, 300.0, 72.0), output);
    
