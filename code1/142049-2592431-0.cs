    DicomDecoder decoder = new DicomDecoder();
    using (AtalaImage image = decoder.Read(stream, frameIndex, null)) {
        AtalaImage imageToSave = null;
        if (image.PixelFormat == PixelFormat.Pixel16bppGrayscale) {
            imageToSave = image.GetChangedPixelFormat(PixelFormat.Pixel8bppGrayscale);
        }
        else if (image.PixelFormat == PixelFormat.Pixel48bppBgr) {
            imageToSave = image.GetChangedPixelFormat(PixelFormat.Pixel24bppBgr);
        }
        else {
            imageToSave = image;
        }
        imageToSave.Save(outputStream, new JpegEncoder(), null);
        if (imageToSave != image)
            imageToSave.Dispose();
    }
