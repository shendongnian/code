    /// <summary>
	/// Converts a WPF bitmap to a System.Drawing.Bitmap
	/// </summary>
	/// <param name="wpfBitmap">BitmapSource to convert</param>
	/// <returns>A GDI Bitmap</returns>
	public static System.Drawing.Bitmap GdiBitmapFromWpfBitmap(BitmapSource wpfBitmap)
	{
		PngBitmapEncoder encoder = new PngBitmapEncoder();
		encoder.Frames.Add(BitmapFrame.Create(wpfBitmap));
		MemoryStream imageStream = new MemoryStream();
		encoder.Save(imageStream);
		System.Drawing.Bitmap gdiBitmap = new System.Drawing.Bitmap(imageStream);
		imageStream.Close();
		imageStream.Dispose();
		return gdiBitmap;
	}
