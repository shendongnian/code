    MyPoints myPoints = new MyPoints();
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        //Use default property values
        //myPoints.Add(new MyPoints.DrawingPoint(e.Location));
        MyPoints.DrawingPoint newPoint = new MyPoints.DrawingPoint();
        newPoint.Dot = new Rectangle(e.Location, new Size(4, 4));
        newPoint.DrawingPen = new Pen(Color.Red, 2);
        myPoints.DrawingPoints.Add(newPoint);
        ((Control)sender).Invalidate();
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        foreach (MyPoints.DrawingPoint mypoint in myPoints.DrawingPoints) {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawEllipse(mypoint.DrawingPen, mypoint.Dot);
        }
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        myPoints.Dispose();
    }
