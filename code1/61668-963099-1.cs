    void OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        Mouse.Capture(this);
    }
    void Window1_MouseUp(object sender, MouseButtonEventArgs e)
    {
        Mouse.Capture(null);
    }
    void Window1_MouseMove(object sender, MouseEventArgs e)
    {
        Point currentLocation = Mouse.GetPosition(this);
        // Calculate the angle based on the current postion of the mouse
        this.Angle = newAngle;
    }
