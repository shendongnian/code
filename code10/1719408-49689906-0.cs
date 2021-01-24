    public static bool? isLineVertical(Line line)
    {
        double xDiff = Math.Abs(line.X2 - line.X1);
        double yDiff = Math.Abs(line.Y2 - line.Y1);
        bool? vertical = null;
        if (yDiff > xDiff)
        {
            vertical = true;
        }
        else if (xDiff > yDiff)
        {
            vertical = false;
        }
        return vertical;
    }
