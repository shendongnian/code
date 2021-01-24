    private void MouseMove(object sender, MouseEventArgs e)
    {
        if (mouseDown)
        {
            this.Invalidate(rect);
            if (e.Location.X > clickPos.X && e.Location.Y > clickPos.Y)
            {
                rect = new Rectangle(clickPos.X, clickPos.Y, e.Location.X - clickPos.X, e.Location.Y - clickPos.Y);
            }
            else if (e.Location.X > clickPos.X && e.Location.Y < clickPos.Y)
            {
                rect = new Rectangle(clickPos.X, e.Location.Y, e.Location.X - clickPos.X, clickPos.Y - e.Location.Y);
            }
            else if (e.Location.X < clickPos.X && e.Location.Y < clickPos.Y)
            {
                rect = new Rectangle(e.Location.X, e.Location.Y, clickPos.X - e.Location.X, clickPos.Y - e.Location.Y);
            }
            else if (e.Location.X < clickPos.X && e.Location.Y > clickPos.Y)
            {
                rect = new Rectangle(e.Location.X, clickPos.Y, clickPos.X - e.Location.X, e.Location.Y - clickPos.Y);
            }
            this.Invalidate(rect);
        }
    }
