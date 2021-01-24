    private List<Point> locations = new List<Point>();
    private void button1_MouseDown(object sender, MouseEventArgs e)
    {
        isMouseDown = true;
        locations.Add(new Point(button1.Location.X, button1.Location.Y)); // where locations[0] is your first point
    }
    private void button1_MouseMove(object sender, MouseEventArgs e)
    {
        if(isMouseDown)
        {
            button1.Left = e.X + button1.Left - (button1.Width / 2);
            button1.Top = e.Y + button1.Top - (button1.Height / 2);
        }
    }
