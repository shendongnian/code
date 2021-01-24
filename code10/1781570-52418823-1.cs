    public static VectorOfPoint Clone(this VectorOfPoint contour)
    {
        List<Point> cloned = new List<Point>(contour.Size);
        for (int i = 0; i < contour.Size; i++)
        {
            Point p = new Point(contour[i].X, contour[i].Y);
            cloned.Add(p);
        }
        return new VectorOfPoint(cloned.ToArray());
    }
