    using (Bitmap bmp = new Bitmap ( 100, 100 ))
    using (Graphics g = Graphics.FromImage ( bmp ))
    using (Pen p = new Pen ( Color.FromArgb ( 128, Color.Blue ), 1 ))
    using (Brush b = new SolidBrush ( Color.FromArgb ( 128, Color.Blue ) ))
    {
        g.FillEllipse ( b, 0, 0, 99, 99 );    
        g.FillRegion ( b, pictureBox1.Region );
    }
