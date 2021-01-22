    private bool _Moving = false;
    private Point _Offset;
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        _Moving = true;
        _Offset = new Point(e.X, e.Y);
    }
    
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (_Moving)
        {
            Point newlocation = this.Location;
            newlocation.X += e.X - _Offset.X;
            newlocation.Y += e.Y - _Offset.Y;
            this.Location = newlocation;
        }
    }
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        if (_Moving)
        {
            _Moving = false;
        }
    }
