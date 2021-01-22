    public static List<Point3D> IntersectionOfLineSegmentWithBox(
        Point3D segmentBegin, Point3D segmentEnd, Point3D boxCenter, Size3D boxSize)
    {
        var segmentBeginToEnd = segmentEnd - segmentBegin;
        var boxMinToMax = new Vector3D(boxSize.X, boxSize.Y, boxSize.Z);
        var boxMin = boxCenter - boxMinToMax / 2;
        var boxMax = boxCenter + boxMinToMax / 2;
        var segmentBeginToBoxMin = boxMin - segmentBegin;
        var segmentBeginToBoxMax = boxMax - segmentBegin;
        var intersectionPoints = new List<Point3D>();
        foreach (Axis axis in Enum.GetValues(typeof(Axis)))
        {
            if (segmentBeginToEnd.GetCoordinate(axis) == 0) // parallel
            {
                if (segmentBeginToBoxMin.GetCoordinate(axis) < 0 || segmentBeginToBoxMax.GetCoordinate(axis) > 0)
                    return intersectionPoints; // segment is not between planes
                else
                    continue; // segment is between planes
            }
            else
            {
                var t1 = (segmentBeginToBoxMin.GetCoordinate(axis)) / segmentBeginToEnd.GetCoordinate(axis);
                var t2 = (segmentBeginToBoxMax.GetCoordinate(axis)) / segmentBeginToEnd.GetCoordinate(axis);
                var tNear = Math.Min(t1, t2);
                var tFar = Math.Max(t1, t2);
                if (tNear >= 0 && tNear <= 1)
                {
                    var near = segmentBegin + segmentBeginToEnd * tNear;
                    intersectionPoints.Add(near);
                }
                if (tFar >= 0 && tFar <= 1)
                {
                    var far = segmentBegin + segmentBeginToEnd * tFar;
                    intersectionPoints.Add(far);
                }
                return intersectionPoints;
            }
        }
        throw new InvalidOperationException();
    }
-----
    public enum Axis
    {
        X,
        Y,
        Z
    }
