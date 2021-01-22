    private bool dragging = false;
    private Point dragCursorPoint;
    private Point dragFormPoint;
    
    private void FormMain_MouseDown(object sender, MouseEventArgs e)
    {
        dragging = true;
        dragCursorPoint = Cursor.Position;
        dragFormPoint = this.Location;
    }
    
    private void FormMain_MouseMove(object sender, MouseEventArgs e)
    {
        if (dragging)
        {
            Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
            this.Location = Point.Add(dragFormPoint, new Size(dif));
        }
    }
    
    private void FormMain_MouseUp(object sender, MouseEventArgs e)
    {
        dragging = false;
    }
