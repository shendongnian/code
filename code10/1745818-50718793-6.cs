    void moved(MoveLabel sender)
    {
        points[sender.PointIndex] = 
                new Point(sender.Left - sender.Width / 2, sender.Top - sender.Height / 2);
        panel.Invalidate();
    }
