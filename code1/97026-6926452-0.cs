	Graphics canvas;
	Bitmap iconBitmap = new Bitmap(16, 16);
	canvas = Graphics.FromImage(iconBitmap);
	
	canvas.DrawIcon(YourProject.Resources.YourIcon, 0, 0);
	StringFormat format = new StringFormat();
	format.Alignment = StringAlignment.Center;
	
	canvas.DrawString(
		"2",
		new Font("Calibri", 8, FontStyle.Bold),
		new SolidBrush(Color.FromArgb(40, 40, 40)),
		new RectangleF(0, 3, 16, 13),
		format
	);
	notifyIcon.Icon = Icon.FromHandle(iconBitmap.GetHicon());
