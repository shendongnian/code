    private Point location => new Point(button1.Location.X, button1.Location.Y);
    private void button1_MouseDown(object sender, MouseEventArgs e)
    {
        isMouseDown = true;
        location = new Point(button1.Location.X, button1.Location.Y);
    }
    private void button1_MouseMove(object sender, MouseEventArgs e)
    {
        if(isMouseDown)
        {
            button1.Left = e.X + button1.Left - (button1.Width / 2);
            button1.Top = e.Y + button1.Top - (button1.Height / 2);
        }
    }
