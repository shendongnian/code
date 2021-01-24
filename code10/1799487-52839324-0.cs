    abstract class Point2D
    {
        public virtual string X { get; set; }
    }
    abstract class Point3D : Point2D
    {
        public virtual string Y { get; set; }
    }
    class Point : Point3D
    {
        // does not need extra function, this *is* a Point2D AND a Point3D
    }
