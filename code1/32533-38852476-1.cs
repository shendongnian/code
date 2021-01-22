    public static Bitmap GetBMPTransparent(Bitmap bmp, int TranspFactor)
{
	Bitmap transpBmp = new Bitmap(bmp.Width, bmp.Height);
	using (ImageAttributes attr = new ImageAttributes()) {
		ColorMatrix matrix = new ColorMatrix { Matrix33 = Convert.ToSingle(TranspFactor / 255) };
		attr.SetColorMatrix(matrix);
		using (Graphics g = Graphics.FromImage(transpBmp)) {
			g.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
		}
	}
	return transpBmp;
