    // open a sequence of images
    FileSystemImageSource source = new FileSystemImageSource("path-to-tiff", true);
    using (FileStream outstm = new FileStream("outputpath", FileMode.Create)) {
        // make an encoder and a threshold command
        TiffEncoder encoder = new TiffEncoder(TiffCompression.Auto, true);
        // dynamic is good for documents -- needs the DocumentImaging SDK
        ImageCommand threshold = new DynamicThreshold();
        while (source.HasMoreImages()) {
            // get next image
            AtalaImage image = source.AcquireNext();
            AtalaImage final = threshold.Apply(image).Image;
            try {
                encoder.Save(outstm, final, null);
            }
            finally {
                // free memory from current image
                final.Dispose();
                // release the source image back to the image source
                source.Release(image);
            }
        }
    }
            
