    private static Point GetAutoScrollPosition(Panel panel)
    {
        return panel.AutoScrollPosition;
    }
    
    private static void SetAutoScrollPosition(Panel panel, Point position)
    {
        panel.AutoScrollPosition = new Point(-position.X, -position.Y);
    }
