    public static List<Point3D> IntersectionOfLineSegmentWithAxisAlignedBox(
        Point3D segmentBegin, Point3D segmentEnd, Point3D boxCenter, Size3D boxSize)
    {
        var beginToEnd = segmentEnd - segmentBegin;
        var minToMax = new Vector3D(boxSize.X, boxSize.Y, boxSize.Z);
        var min = boxCenter - minToMax / 2;
        var max = boxCenter + minToMax / 2;
        var beginToMin = min - segmentBegin;
        var beginToMax = max - segmentBegin;
        var tNear = double.MinValue;
        var tFar = double.MaxValue;
        var intersections = new List<Point3D>();
        foreach (Axis axis in Enum.GetValues(typeof(Axis)))
        {
            if (beginToEnd.GetCoordinate(axis) == 0) // parallel
            {
                if (beginToMin.GetCoordinate(axis) > 0 || beginToMax.GetCoordinate(axis) < 0)
                    return intersections; // segment is not between planes
            }
            else
            {
                var t1 = beginToMin.GetCoordinate(axis) / beginToEnd.GetCoordinate(axis);
                var t2 = beginToMax.GetCoordinate(axis) / beginToEnd.GetCoordinate(axis);
                var tMin = Math.Min(t1, t2);
                var tMax = Math.Max(t1, t2);
                if (tMin > tNear) tNear = tMin;
                if (tMax < tFar) tFar = tMax;
                if (tNear > tFar || tFar < 0) return intersections;
            }
        }
        if (tNear >= 0 && tNear <= 1) intersections.Add(segmentBegin + beginToEnd * tNear);
        if (tFar >= 0 && tFar <= 1) intersections.Add(segmentBegin + beginToEnd * tFar);
        return intersections;
    }
-----
    public enum Axis
    {
        X,
        Y,
        Z
    }
