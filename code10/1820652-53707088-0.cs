    Point _point;
    void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        ... // calculate new coordinates/scale factor/whatever here
        _point = ... ; // store results in fields
        Invalidate(); // this will cause repaint every time you move mouse
    }
    void Form1_Paint(object sender, PaintEventArgs e)
    {
        ... // take values from fields
        e.Graphics.DrawRectangle(pen, rect); // draw
    }
