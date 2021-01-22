    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Point p1 = new Point(5 + xOffset,0);
        Point p2 = new Point(10 + xOffset, 5);
        Point p3 = new Point(5 + xOffset, 10);
        Point p4 = new Point(0 + xOffset, 5);
        Point[] ps = { p1, p2, p3, p4, p1 };
        g.DrawLines(Pens.Black, ps);
    }
