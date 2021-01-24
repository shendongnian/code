    public FrmDrawing()
    {
      InitializeComponent();
      pnlDraw.Image = new Bitmap(pnlDraw.Width, pnlDraw.Height);
    }
    private void pnlDraw_MouseMove(object sender, MouseEventArgs e)
    {
        if (moving && x!=-1 && y!=-1 )
        {
            // Create Graphics object dynamically
            using (var g = Graphics.FromImage(pnlDraw.Image))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var pen = new Pen(Color.Black, 5))
                {
                    pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    g.DrawLine(pen, new Point(x, y), e.Location);  
                }
            }
            // This is necessary; otherwise, we won't see the changes until
            // the picture box is repainted by the OS
            pnlDraw.Invalidate();
            x = e.X;
            y = e.Y;
        }
    }
