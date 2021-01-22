    private Point _Offset = Point.Empty;
    protected override void MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            _Offset = new Point(e.X, e.Y);
        }
    }
    protected override void MouseMove(object sender, MouseEventArgs e)
    {
        if (_Offset != Point.Empty)
        {
            Point newlocation = this.Location;
            newlocation.X += e.X - _Offset.X;
            newlocation.Y += e.Y - _Offset.Y;
            this.Location = newlocation; 
        }
    }
    protected override void MouseUp(object sender, MouseEventArgs e)
    {
        if (_Offset != Point.Empty)
        {
            _Offset = Point.Empty;
        }
    }
