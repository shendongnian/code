    public static double GetCoordinate(this Point3D point, Axis axis)
    {
        switch (axis)
        {
            case Axis.X:
                return point.X;
            case Axis.Y:
                return point.Y;
            case Axis.Z:
                return point.Z;
            default:
                throw new ArgumentException();
        }
    }
    public static double GetCoordinate(this Vector3D vector, Axis axis)
    {
        switch (axis)
        {
            case Axis.X:
                return vector.X;
            case Axis.Y:
                return vector.Y;
            case Axis.Z:
                return vector.Z;
            default:
                throw new ArgumentException();
        }
    }
