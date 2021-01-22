    using (System.Drawing.Graphics graphics = CreateGraphics())
	{
	    System.Drawing.Size size = TextRenderer.MeasureText(graphics, id, e.Appearance.Font);
		if (size.Width > e.Column.Width)
		{
			int charFit = (int)(((double)e.Column.Width / (double)size.Width) * (double)id.Length);
			if (id.Length - charFit + 2 < id.Length)
			{
			    e.DisplayText = string.Format("{0}{1}","...", id.Substring(id.Length - charFit + 2));
			}
		}
	}
