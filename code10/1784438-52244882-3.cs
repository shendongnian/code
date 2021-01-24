    Bitmap bmp = new Bitmap(500, 500);
    using (Graphics g = Graphics.FromImage(bmp))
    {
        g.Clear(Color.Transparent);
        //g.SmoothingMode = SmoothingMode.AntiAlias;
        g.CompositingMode = CompositingMode.SourceCopy;
        g.FillEllipse(Brushes.DarkGreen, 100, 100, 300, 300);
        g.FillEllipse(Brushes.Transparent, 200, 200, 100, 100);
    }
    pictureBox1.Image = bmp;
