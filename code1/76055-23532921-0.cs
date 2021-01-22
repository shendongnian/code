	Font i_Courier = new Font("Courier New", 11, GraphicsUnit.Pixel);
	Win32.SIZE k_Size;
	using (Bitmap i_Bmp = new Bitmap(200, 200, PixelFormat.Format24bppRgb))
	{
		using (Graphics i_Graph = Graphics.FromImage(i_Bmp))
		{
			IntPtr h_DC = i_Graph.GetHdc();
			IntPtr h_OldFont = Win32.SelectObject(h_DC, i_Courier.ToHfont());
			Win32.GetTextExtentPoint32(h_DC, "Áp", 2, out k_Size);
			Win32.SelectObject(h_DC, h_OldFont);
			i_Graph.ReleaseHdc();
		}
	}
