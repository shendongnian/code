    public class CustomCursor
    {
      // alphaLevel is a value between 0 and 255. For 50% transparency, use 128.
      public Cursor CreateCursorFromBitmap(Bitmap bitmap, byte alphaLevel, Point hotSpot)
      {
        Bitmap cursorBitmap = null;
        External.ICONINFO iconInfo = new External.ICONINFO();
        Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
    
        try
        {
          // Here, the premultiplied alpha channel is specified
          cursorBitmap = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format32bppPArgb);
    
          // I'm assuming the source bitmap can be locked in a 24 bits per pixel format
          BitmapData bitmapData = bitmap.LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
          BitmapData cursorBitmapData = cursorBitmap.LockBits(rectangle, ImageLockMode.WriteOnly, cursorBitmap.PixelFormat);
    
          // Use either SafeCopy() or UnsafeCopy() to set the bitmap contents
          SafeCopy(bitmapData, cursorBitmapData, alphaLevel);
          //UnsafeCopy(bitmapData, cursorBitmapData, alphaLevel);
    
          cursorBitmap.UnlockBits(cursorBitmapData);
          bitmap.UnlockBits(bitmapData);
    
          if (!External.GetIconInfo(cursorBitmap.GetHicon(), out iconInfo))
            throw new Exception("GetIconInfo() failed.");
    
          iconInfo.xHotspot = hotSpot.X;
          iconInfo.yHotspot = hotSpot.Y;
          iconInfo.IsIcon = false;
    
          IntPtr cursorPtr = External.CreateIconIndirect(ref iconInfo);
          if (cursorPtr == IntPtr.Zero)
            throw new Exception("CreateIconIndirect() failed.");
    
          return (new Cursor(cursorPtr));
        }
        finally
        {
          if (cursorBitmap != null)
            cursorBitmap.Dispose();
          if (iconInfo.ColorBitmap != IntPtr.Zero)
            External.DeleteObject(iconInfo.ColorBitmap);
          if (iconInfo.MaskBitmap != IntPtr.Zero)
            External.DeleteObject(iconInfo.MaskBitmap);
        }
      }
    
      private void SafeCopy(BitmapData srcData, BitmapData dstData, byte alphaLevel)
      {
        for (int y = 0; y < srcData.Height; y++)
          for (int x = 0; x < srcData.Width; x++)
          {
            byte b = Marshal.ReadByte(srcData.Scan0, y * srcData.Stride + x * 3);
            byte g = Marshal.ReadByte(srcData.Scan0, y * srcData.Stride + x * 3 + 1);
            byte r = Marshal.ReadByte(srcData.Scan0, y * srcData.Stride + x * 3 + 2);
    
            Marshal.WriteByte(dstData.Scan0, y * dstData.Stride + x * 4, b);
            Marshal.WriteByte(dstData.Scan0, y * dstData.Stride + x * 4 + 1, g);
            Marshal.WriteByte(dstData.Scan0, y * dstData.Stride + x * 4 + 2, r);
            Marshal.WriteByte(dstData.Scan0, y * dstData.Stride + x * 4 + 3, alphaLevel);
          }
      }
    
      private unsafe void UnsafeCopy(BitmapData srcData, BitmapData dstData, byte alphaLevel)
      {
        for (int y = 0; y < srcData.Height; y++)
        {
          byte* srcRow = (byte*)srcData.Scan0 + (y * srcData.Stride);
          byte* dstRow = (byte*)dstData.Scan0 + (y * dstData.Stride);
          
          for (int x = 0; x < srcData.Width; x++)
          {
            dstRow[x * 4] = srcRow[x * 3];
            dstRow[x * 4 + 1] = srcRow[x * 3 + 1];
            dstRow[x * 4 + 2] = srcRow[x * 3 + 2];
            dstRow[x * 4 + 3] = alphaLevel;
          }
        }
      }
    }
