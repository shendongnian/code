	public Color GetPixel(int x, int y)
	{
		Color clr = Color.Empty;
		// Get the bit index of the specified pixel
		int biti = (Stride > 0 ? y : y - Height + 1) * Stride * 8 + x * ColorDepth;
		// Get the byte index
		int i = biti / 8;
		// Get color components count
		int cCount = ColorDepth / 8;
		int dataLength = _imageData.Length - cCount;
		if (i > dataLength)
		{
			throw new IndexOutOfRangeException();
		}
		if (ColorDepth == 32) // For 32 bpp get Red, Green, Blue and Alpha
		{
			byte b = _imageData[i];
			byte g = _imageData[i + 1];
			byte r = _imageData[i + 2];
			byte a = _imageData[i + 3]; // a
			clr = Color.FromArgb(a, r, g, b);
		}
		if (ColorDepth == 24) // For 24 bpp get Red, Green and Blue
		{
			byte b = _imageData[i];
			byte g = _imageData[i + 1];
			byte r = _imageData[i + 2];
			clr = Color.FromArgb(r, g, b);
		}
		if (ColorDepth == 8)
		// For 8 bpp get color value (Red, Green and Blue values are the same)
		{
			byte c = _imageData[i];
			clr = Color.FromArgb(c, c, c);
		}
		if (ColorDepth == 4)
		{
			byte c = 0;
			if (biti % 8 == 0)
			{
				c = (byte)(_imageData[i] >> 4);
			}
			else
			{
				c = (byte)(_imageData[i] & 0xF);
			}
			clr = Color.FromArgb(c, c, c);
		}
		if (ColorDepth == 1)
		{
			int bbi = biti % 8;
			byte mask = (byte)(1 << bbi);
			byte c = (byte)((_imageData[i] & mask) != 0 ? 255 : 0);
			clr = Color.FromArgb(c, c, c);
		}
		return clr;
	}
	public void SetPixel(int x, int y, Color color)
	{
		if (!IsLocked) throw new Exception();
		// Get the bit index of the specified pixel
		int biti = (Stride > 0 ? y : y - Height + 1) * Stride * 8 + x * ColorDepth;
		// Get the byte index
		int i = biti / 8;
		// Get color components count
		int cCount = ColorDepth / 8;
		try
		{
			if (ColorDepth == 32) // For 32 bpp set Red, Green, Blue and Alpha
			{
				_imageData[i] = color.B;
				_imageData[i + 1] = color.G;
				_imageData[i + 2] = color.R;
				_imageData[i + 3] = color.A;
			}
			if (ColorDepth == 24) // For 24 bpp set Red, Green and Blue
			{
				_imageData[i] = color.B;
				_imageData[i + 1] = color.G;
				_imageData[i + 2] = color.R;
			}
			if (ColorDepth == 8)
			// For 8 bpp set color value (Red, Green and Blue values are the same)
			{
				_imageData[i] = color.B;
			}
			if (ColorDepth == 4)
			{
				if (biti % 8 == 0)
				{
					_imageData[i] = (byte)((_imageData[i] & 0xF) | (color.B << 4));
				}
				else
				{
					_imageData[i] = (byte)((_imageData[i] & 0xF0) | color.B);
				}
			}
			if (ColorDepth == 1)
			{
				int bbi = biti % 8;
				byte mask = (byte)(1 << bbi);
				if (color.B != 0)
				{
					_imageData[i] |= mask;
				}
				else
				{
					_imageData[i] &= (byte)~mask;
				}
			}
		}
		catch (Exception ex)
		{
			throw new Exception("(" + x + ", " + y + "), " + _imageData.Length + ", " + ex.Message + ", i=" + i);
		}
	}
