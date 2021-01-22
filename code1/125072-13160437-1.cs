    public Image RotateImage(Image img)
    {
    	var bmp = new Bitmap(img);
		using (Graphics gfx = Graphics.FromImage(bmp))
		{
			gfx.Clear(Color.White);
			gfx.DrawImage(img, 0, 0, img.Width, img.Height);
		}
		bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
		return bmp;
    }
