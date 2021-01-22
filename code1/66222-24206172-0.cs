    Bitmap canvas = new Bitmap(secScreen.Bounds.Width, secScreen.Bounds.Height);
    Graphics g = Graphics.FromImage(canvas);
    g.Clear(System.Drawing.Color.Yellow);
    
    MemoryStream stream = new MemoryStream ();
    canvas.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
    ImageSource isrg = (ImageSource)new ImageSourceConverter().ConvertFrom(stream);
