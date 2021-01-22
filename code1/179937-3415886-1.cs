    private static Bitmap convertToBitonal(Bitmap original)
    {
        int sourceStride;
        byte[] sourceBuffer = extractBytes(original, out sourceStride);
    
        // Create destination bitmap
        Bitmap destination = new Bitmap(original.Width, original.Height,
            PixelFormat.Format1bppIndexed);
    
        destination.SetResolution(original.HorizontalResolution, original.VerticalResolution);
    
        // Lock destination bitmap in memory
        BitmapData destinationData = destination.LockBits(
            new Rectangle(0, 0, destination.Width, destination.Height),
            ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
    
        // Create buffer for destination bitmap bits
        int imageSize = destinationData.Stride * destinationData.Height;
        byte[] destinationBuffer = new byte[imageSize];
    
        int sourceIndex = 0;
        int destinationIndex = 0;
        int pixelTotal = 0;
        byte destinationValue = 0;
        int pixelValue = 128;
        int height = destination.Height;
        int width = destination.Width;
        int threshold = 500;
    
        for (int y = 0; y < height; y++)
        {
            sourceIndex = y * sourceStride;
            destinationIndex = y * destinationData.Stride;
            destinationValue = 0;
            pixelValue = 128;
    
            for (int x = 0; x < width; x++)
            {
                // Compute pixel brightness (i.e. total of Red, Green, and Blue values)
                pixelTotal = sourceBuffer[sourceIndex + 1] + sourceBuffer[sourceIndex + 2] +
                    sourceBuffer[sourceIndex + 3];
    
                if (pixelTotal > threshold)
                    destinationValue += (byte)pixelValue;
    
                if (pixelValue == 1)
                {
                    destinationBuffer[destinationIndex] = destinationValue;
                    destinationIndex++;
                    destinationValue = 0;
                    pixelValue = 128;
                }
                else
                {
                    pixelValue >>= 1;
                }
    
                sourceIndex += 4;
            }
    
            if (pixelValue != 128)
                destinationBuffer[destinationIndex] = destinationValue;
        }
    
        Marshal.Copy(destinationBuffer, 0, destinationData.Scan0, imageSize);
        destination.UnlockBits(destinationData);
        return destination;
    }
    
    private static byte[] extractBytes(Bitmap original, out int stride)
    {
        Bitmap source = null;
    
        try
        {
            // If original bitmap is not already in 32 BPP, ARGB format, then convert
            if (original.PixelFormat != PixelFormat.Format32bppArgb)
            {
                source = new Bitmap(original.Width, original.Height, PixelFormat.Format32bppArgb);
                source.SetResolution(original.HorizontalResolution, original.VerticalResolution);
                using (Graphics g = Graphics.FromImage(source))
                {
                    g.DrawImageUnscaled(original, 0, 0);
                }
            }
            else
            {
                source = original;
            }
    
            // Lock source bitmap in memory
            BitmapData sourceData = source.LockBits(
                new Rectangle(0, 0, source.Width, source.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
    
            // Copy image data to binary array
            int imageSize = sourceData.Stride * sourceData.Height;
            byte[] sourceBuffer = new byte[imageSize];
            Marshal.Copy(sourceData.Scan0, sourceBuffer, 0, imageSize);
    
            // Unlock source bitmap
            source.UnlockBits(sourceData);
    
            stride = sourceData.Stride;
            return sourceBuffer;
        }
        finally
        {
            if (source != original)
                source.Dispose();
        }        
    }
