    Point firstPoint;
    Point seondPoint;
    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
        if (this.firstPoint == null) {
            this.firstPoint = e.Location;
        }
        
        if (this.secondPoint == null) {
            this.secondPoint = e.Location;
        }
    
        panel1.Invalidate();
    }
    private void panel1_Paint_1(object sender, PaintEventArgs e)
    {       
        Using (pn as new Pen(Color.Blue, 5))
        {
            e.Graphics.DrawLine(pn, firstPoint, secondPoint);
        }
    }
