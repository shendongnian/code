    public bool Equals(PointF pt1, PointF pt2)
    {
       return GetCell(pt1.X) == GetCell(pt2.X)
           && GetCell(pt1.Y) == GetCell(pt2.Y);
    }
    public int GetHashCode(PointF pt)
    {
       return GetCell(pt.X) ^ GetCell(pt.Y);
    }
    private static int GetCell(float f)
    {
        return (int)(f / 10); // cell size is 10 pixels
    }
