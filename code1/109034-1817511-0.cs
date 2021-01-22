public ScrollHolder()
{
	this.Size = new Size(21, 21);
	this.BackColor = SystemColors.Control;
}
protected override void OnPaint(PaintEventArgs e)
{
	Point bottomLeft = new Point(0, this.Height);
	Point topRight = new Point(this.Width, 0);
	Pen controlDark = SystemPens.ControlDark;
	Pen controlLightLight = SystemPens.ControlLightLight;
	Pen controlDark2Px = new Pen(SystemColors.ControlDark, 2);
	Point bottomRight = new Point(this.Width, this.Height);
	e.Graphics.DrawLine(
		controlLightLight, 
		bottomLeft.X, 
		bottomLeft.Y - 2, 
		bottomRight.X, 
		bottomRight.Y - 2);
	e.Graphics.DrawLine(controlDark, bottomLeft, topRight);
	e.Graphics.DrawLine(
		controlLightLight, 
		bottomLeft.X + 1, 
		bottomLeft.Y, 
		topRight.X, 
		topRight.Y + 1);
	e.Graphics.DrawLine(controlDark2Px, bottomLeft, bottomRight);
	e.Graphics.DrawLine(controlDark2Px, bottomRight, topRight);
	int xNumberOfGripDots = this.Width / 4;
	for (int x = 1; x &lt; xNumberOfGripDots; x++)
	{
		for (int y = 1; y &lt; 5 - x; y++)
		{
			DrawGripDot(e.Graphics, new Point(
				this.Width - (y * 4), this.Height - (x * 4) - 1));
		}
	}
}
private static void DrawGripDot(Graphics g, Point location)
{
	g.FillRectangle(
        SystemBrushes.ControlLightLight, location.X + 1, location.Y + 1, 2, 2);
	g.FillRectangle(SystemBrushes.ControlDark, location.X, location.Y, 2, 2);
}
protected override void OnResize(EventArgs e)
{
	this.SetRegion();
	base.OnResize(e);
}
private void SetRegion()
{
	GraphicsPath path = new GraphicsPath();
	path.AddPolygon(new Point[] 
	{ 
		new Point(this.Width, 0), 
		new Point(this.Width, this.Height),
		new Point(0, this.Height) 
	});
	this.Region = new Region(path);
}
