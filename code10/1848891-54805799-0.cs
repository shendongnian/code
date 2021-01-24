	public Bitmap ConvertByteArrayToBitmap(byte[] Array)
	{
		if (Array == null) return null;
		using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
		{
			ms.Write(Array, 0, Array.Length);
			ms.Position = 0L;
			return new Bitmap(ms);
		}
	}
