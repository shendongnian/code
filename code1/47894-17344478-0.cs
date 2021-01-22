    public Bitmap ShowImage(byte[] sender, EventImageParams e)
        {
            Bitmap bitmap = new Bitmap(e.width, e.height, PixelFormat.Format24bppRgb);
            BitmapData bmData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr pNative = bmData.Scan0;
            Marshal.Copy(sender, 0, pNative, (e.width  * e.height * 3));
         //    
            bitmap.UnlockBits(bmData);
            return bitmap;
        }
