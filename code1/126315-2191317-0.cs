    private void LoadAndResizeImage(string sImagepath, int iMaxHeight, int iMaxWidth, int iMinX, int iMinY)
	{
		int wdt = iMaxWidth;
		int hgt = iMaxHeight;
		int partialX = iMinX;
		int partialY = iMinY;
		pictureBox1.ImageLocation = sImagepath;
		if ((pictureBox1.Image.Height > iMaxHeight) || (pictureBox1.Image.Width > iMaxWidth))
		{
			if ((pictureBox1.Image.Width / iMaxWidth) > (pictureBox1.Image.Height / iMaxHeight))
			{
				wdt = iMaxWidth;
				double ratio = (double)pictureBox1.Image.Height / (double)pictureBox1.Image.Width;
				hgt = (int)(iMaxWidth * ratio);
			}
			else
			{
				hgt = iMaxHeight;
				double ratio = (double)pictureBox1.Image.Width / (double)pictureBox1.Image.Height;
				wdt = (int)(iMaxHeight * ratio);
			}
		}
		else
		{
			hgt = pictureBox1.Image.Height;
			wdt = pictureBox1.Image.Width;
		}
		if (wdt < iMaxWidth)
		{
			partialX = (iMaxWidth - wdt) / 2;
			partialX += iMinX;
		}
		else
		{
			partialX = iMinX;
		}
		if (hgt < iMaxHeight)
		{
			partialY = (iMaxHeight - hgt) / 2;
			partialY += iMinY;
		}
		else
		{
			partialY = iMinY;
		}
		//Set size
		pictureBox1.Height = hgt;
		pictureBox1.Width = wdt;
		pictureBox1.Left = partialX;
		pictureBox1.Top = partialY;
	}
