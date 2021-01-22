	Bitmap bmp = new Bitmap("myimage.jpg");
	BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
		ImageLockMode.ReadOnly,
		PixelFormat.Format32bppRgb);
	// copy as bytes
	int byteCount = data.Stride * data.Height;
	byte[] bytes = new byte[byteCount];
	System.Runtime.InteropServices.Marshal.Copy(data.Scan0, bytes, 0, byteCount);
	// -- OR -- copy as ints
	int wordCount = byteCount / 4;
	Int32[] words = new Int32[wordCount];
	System.Runtime.InteropServices.Marshal.Copy(data.Scan0, words, 0, wordCount);
	bmp.UnlockBits(data);
