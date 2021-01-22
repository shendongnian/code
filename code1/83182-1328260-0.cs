	public void GetBytesFromColor(int color, out a, out r, out g, out b)
	{
		Color c = Color.FromArgb(color);
		a = c.A;
		r = c.R;
		g = c.G;
		b = c.B;
	}
