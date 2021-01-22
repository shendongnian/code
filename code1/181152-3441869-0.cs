    private bool mouseIsDown = false;
    private Point firstPoint;
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        firstPoint = e.Location;
        mouseIsDown = true;
    }
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        mouseIsDown = false;
    }
