    private void MouseDown(object sender, MouseEventArgs e)
    {
        mouseDown = true;
        clickPos = e.Location;
        rect = new Rectangle(clickPos, new Size(0, 0));
    }
