    Rectangle mouseBounds = new Rectangle(Cursor.Positon.X, Cursor.Positon.Y, Cursor.Width, Cursor.Height);
    
    Rectangle iconBounds = new Rectangle(getIconX(), getIconY());
    if (mouseBounds.Intersects(iconBounds))
    {
       MessageBox.Show("Is hovering over icon");
    }
