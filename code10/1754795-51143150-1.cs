    public static Bitmap BitmapTo1Bpp(Bitmap source)
    {
        Rectangle rect = new Rectangle(0, 0, source.Width, source.Height);
        Bitmap dest = new Bitmap(rect.Width, rect.Height, PixelFormat.Format1bppIndexed);
        dest.SetResolution(source.HorizontalResolution, source.VerticalResolution);
        BitmapData sourceData = source.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format1bppIndexed);
        BitmapData targetData = dest.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
        Int32 actualDataWidth = (rect.Width + 7) / 8;
        Int32 h = source.Height;
        Int32 origStride = sourceData.Stride;
        Int32 targetStride = targetData.Stride;
        // buffer for one line of image data.
        Byte[] imageData = new Byte[actualDataWidth];
        IntPtr sourcePos = sourceData.Scan0;
        IntPtr destPos = targetData.Scan0;
        // Copy line by line, skipping by stride but copying actual data width
        for (Int32 y = 0; y < h; y++)
        {
            Marshal.Copy(sourcePos, imageData, 0, actualDataWidth);
            Marshal.Copy(imageData, 0, destPos, actualDataWidth);
            sourcePos = new IntPtr(sourcePos.ToInt64() + origStride);
            destPos = new IntPtr(destPos.ToInt64() + targetStride);
        }
        dest.UnlockBits(targetData);
        source.UnlockBits(sourceData);
        return dest;
    }
