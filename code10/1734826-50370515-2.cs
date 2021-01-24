    public static SKBitmap OpenTiff(Stream tiffStream)
    {
        // open a TIFF stored in the stream
        using (var tifImg = Tiff.ClientOpen("in-memory", "r", tiffStream, new TiffStream()))
        {
            // read the dimensions
            var width = tifImg.GetField(TiffTag.IMAGEWIDTH)[0].ToInt();
            var height = tifImg.GetField(TiffTag.IMAGELENGTH)[0].ToInt();
            // create the bitmap
            var bitmap = new SKBitmap();
            var info = new SKImageInfo(width, height);
            // create the buffer that will hold the pixels
            var raster = new int[width * height];
            // get a pointer to the buffer, and give it to the bitmap
            var ptr = GCHandle.Alloc(raster, GCHandleType.Pinned);
            bitmap.InstallPixels(info, ptr.AddrOfPinnedObject(), info.RowBytes, null, (addr, ctx) => ptr.Free(), null);
            // read the image into the memory buffer
            if (!tifImg.ReadRGBAImageOriented(width, height, raster, Orientation.TOPLEFT))
            {
                // not a valid TIF image.
                return null;
            }
            // swap the red and blue because SkiaSharp may differ from the tiff
            if (SKImageInfo.PlatformColorType == SKColorType.Bgra8888)
            {
                SKSwizzle.SwapRedBlue(ptr.AddrOfPinnedObject(), raster.Length);
            }
            return bitmap;
        }
    }
