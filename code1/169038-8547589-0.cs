    public static int GetAngleBetweenPoints(PointF pt1, PointF pt2)
    {
        float dx = pt2.X - pt1.X;
        float dy = pt2.Y - pt1.Y;
        int deg = Convert.ToInt32(Math.Atan2(dy, dx) * (180 / Math.PI));
        if (deg < 0) { deg += 360; }
        return deg;
    }
