	string file = ((PrintDocument)sender).DocumentName;
	using (System.Drawing.Image img = System.Drawing.Image.FromFile(file))
	{
		Rectangle m = e.MarginBounds;
		if ((double)img.Width / (double)img.Height > (double)m.Width / (double)m.Height) // image is wider
		{
			m.Height = (int)((double)img.Height / (double)img.Width * (double)m.Width);
		}
		else
		{
			m.Width = (int)((double)img.Width / (double)img.Height * (double)m.Height);
		}
		e.Graphics.DrawImage(img, m);
	}
