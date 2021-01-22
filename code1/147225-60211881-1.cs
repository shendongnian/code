    private MyToolTip ttp;
    private int LastX;
    private int LastY;
    public string Caption { get; set; }
    
    private void MyObjectWhichNeedsMovingToolTip_MouseLeave(object sender, EventArgs e)
    {
        ttp.Hide(this);
    }
    private void MyObjectWhichNeedsMovingToolTip_MouseMove(object sender, MouseEventArgs e)
    {
        // This is for stop flickering tooltip
        if (e.X != this.lastX || e.Y != this.lastY)
        {
            ttp.Show(Caption, this, new Point(MyObjectWhichNeedsMovingToolTip.Left + e.X + 10, MyObjectWhichNeedsMovingToolTip.Top + e.Y + 20), int.MaxValue);
            this.lastX = e.X;
            this.lastY = e.Y;
        }
    }
