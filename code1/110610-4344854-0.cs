		{
			// Init buffer
			int w = bmp.PixelWidth;
			int h = bmp.PixelHeight;
			int[] p = bmp.Pixels;
			int len = p.Length;
			byte[] result = new byte[4 * w * h];
			// Copy pixels to buffer
			for (int i = 0, j = 0; i < len; i++, j += 4)
			{
				int color = p[i];
				result[j + 0] = (byte)(color >> 24); // A
				result[j + 1] = (byte)(color >> 16); // R
				result[j + 2] = (byte)(color >> 8);  // G
				result[j + 3] = (byte)(color);       // B
			}
			return result;
		}
