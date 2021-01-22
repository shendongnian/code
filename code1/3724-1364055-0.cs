    FileSystemImageSource source = new FileSystemImageSource("path-to-your-file.tif", true); // true = loop over all frames
    // tiff encoder will auto-select an appropriate compression - CCITT4 for 1 bit.
    TiffEncoder encoder = new TiffEncoder();
    encoder.Append = true;
    
    // DynamicThresholdCommand is very good for documents.  For pictures, use DitherCommand
    DynamicThresholdCommand threshold = new DynamicThresholdCommand();
    using (FileStream outstm = new FileStream("path-to-output.tif", FileMode.Create)) {
        while (source.HasMoreImages()) {
            AtalaImage image = source.AcquireNext();
            AtalaImage finalImage = image;
            // convert when needed.
            if (image.PixelFormat != PixelFormat.Pixel1bppIndexed) {
                finalImage = threshold.Apply().Image;
            }
            encoder.Save(outstm, finalImage, null);
            if (finalImage != image) {
                finalImage.Dispose();
            }
            source.Release(image);
        }
    }
