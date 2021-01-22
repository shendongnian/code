    const int bytesPerPixel = 4;
    int stride = bytesPerPixel * pixelsPerLine;
    UInt32[] pixelBytes = new uint[lineCount * pixelsPerLine];
    
    for (int y = 0; y < lineCount; y++)
    {
        int destinationLineStart = y * pixelsPerLine;
        int sourceLineStart = y * pixelsPerLine;
        for (int x = 0; x < pixelsPerLine; x++)
        {
            pixelBytes[x] = _rgbPixels[x].Pbgr32;
        }
    }
    var bmp = BitmapSource.Create(pixelsPerLine, lineCount, 96, 96, PixelFormats.Pbgra32, null, pixelBytes, stride);
    bmp.Freeze();
    return bmp;
