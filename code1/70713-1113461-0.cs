    private void pictureBox_Paint(object sender, PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		Brush brush = new SolidBrush(Color.Red);
		graphics.FillRectangle(brush, new Rectangle(10, 10, 100, 100));
		Pen pen = new Pen(Color.Green);
		graphics.DrawRectangle(pen, new Rectangle(5, 5, 100, 100));
	}
