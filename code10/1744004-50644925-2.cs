    List<Point> points = new List<Point>();
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        points.Add(e.Location);
        Invalidate();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        this.DoubleBuffered = true;
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        int radius = 3;
        for (int i = points.Count - 1; i >= 0; --i)
        {
            Point p = points[i];
            p.Y += 1;
            if (p.Y > Height)
            {
                points.RemoveAt(i);
                continue;
            }
            points[i] = p;
            e.Graphics.FillEllipse(
                Brushes.Red,
                p.X - radius,
                p.Y - radius,
                2 * radius,
                2 * radius
                );
        }
    }
