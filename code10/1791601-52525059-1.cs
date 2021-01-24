    int i = 0;
    while (i != 1)
    {
        int x = Cursor.Position.X;
        int y = Cursor.Position.Y;
        Graphics g = Graphics.FromHwnd(IntPtr.Zero);
        Rectangle mouseNewRect = new Rectangle(new Point(x, y), new Size(30, 30));
        g.DrawRectangle(new Pen(Brushes.Chocolate), mouseNewRect);
        Wait(500);
        Invalidate();
    }
