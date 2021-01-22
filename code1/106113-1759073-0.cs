    using System.Drawing;
    using System.Drawing.Drawing2D;
    public Image RoundCorners(Image StartImage, int CornerRadius, Color BackgroundColor)
    {
    	CornerRadius *= 2;
    	Bitmap RoundedImage = new Bitmap(StartImage.Width, StartImage.Height);
    	Graphics g = Graphics.FromImage(RoundedImage);
    	g.Clear(BackgroundColor);
    	g.SmoothingMode = SmoothingMode.AntiAlias;
    	Brush brush = new TextureBrush(StartImage);
    	GraphicsPath gp = new GraphicsPath();
    	gp.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90);
    	gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90);
    	gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
    	gp.AddArc(0, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
    	g.FillPath(brush, gp);
    	return RoundedImage;
    }
    
    Image StartImage = Image.FromFile("YourImageFile.jpg");
    Image RoundedImage = this.RoundCorners(StartImage, 25, Color.White);
    //Use RoundedImage...
