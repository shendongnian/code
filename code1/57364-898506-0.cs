    private static Bitmap GetInvalidFrame(Bitmap oldFrame, Bitmap newFrame)
    {
        if (oldFrame.Size != newFrame.Size)
        {
            throw new ArgumentException();
        }
        Bitmap result = new Bitmap(oldFrame.Width, oldFrame.Height, oldFrame.PixelFormat);
        Rectangle lockArea = new Rectangle(Point.Empty, oldFrame.Size);
        PixelFormat format = PixelFormat.Format32bppArgb;
        BitmapData oldData = oldFrame.LockBits(lockArea, ImageLockMode.ReadOnly, format);
        BitmapData newData = newFrame.LockBits(lockArea, ImageLockMode.ReadOnly, format);
        BitmapData resultData = result.LockBits(lockArea, ImageLockMode.WriteOnly, format);
        int len = resultData.Height * Math.Abs(resultData.Stride) / 4;
        unsafe
        {
            int* pOld = (int*)oldData.Scan0;
            int* pNew = (int*)newData.Scan0;
            int* pResult = (int*)resultData.Scan0;
            for (int i = 0; i < len; i++)
            {
                int oldValue = *pOld++;
                int newValue = *pNew++;
                *pResult++ = oldValue != newValue ? newValue : 0 /* replace with 0xff << 24 if you need non-transparent black pixel */;
            }
        }
        oldFrame.UnlockBits(oldData);
        newFrame.UnlockBits(newData);
        result.UnlockBits(resultData);
        return result;
    }
