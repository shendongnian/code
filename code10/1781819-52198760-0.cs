    public void SaveAsJpeg(int width, int height, byte[] argbData, int sourceStride, string path)
    {
    	using (Bitmap img = new Bitmap(width, height, PixelFormat.Format32bppPArgb))
    	{
    		BitmapData data = img.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, img.PixelFormat);
    		for (int y = 0; y < height; y++)
    		{
    			Marshal.Copy(argbData, sourceStride * y, data.Scan0 + data.Stride * y, width * 4);
    		}
    		img.UnlockBits(data);
    		img.Save(path, ImageFormat.Jpeg);
    	}
    }
