    private enum SnapMode { Create, Move }
    private Size gridSizeModeCreate = new Size(30, 30);
    private Size gridSizeModeMove = new Size(15, 15);
    private Point SnapCalculate(Point p, Size s)
    {
        double snapX = p.X + ((Math.Round(p.X / s.Width) - p.X / s.Width) * s.Width);
        double snapY = p.Y + ((Math.Round(p.Y / s.Height) - p.Y / s.Height) * s.Height);
        return new Point(snapX, snapY);
    }
    private Point SnapToGrid(Point p, SnapMode mode)
    {
        if (mode == SnapMode.Create)
            return SnapCalculate(p, gridSizeModeCreate);
        else if (mode == SnapMode.Move)
            return SnapCalculate(p, gridSizeModeMove);
        else
            return new Point(0, 0);
    }
