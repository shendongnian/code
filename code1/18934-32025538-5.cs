    internal struct MyPoint
    {
        internal double X;
        internal double Y;
    }
    // ...
    MyPoint[] points = new MyPoint[1000000];
    Initialize(points);
    // ...
    for (int i = 0; i < points.Length; i++)
    {
        TransformPoint(ref points[i].X, ref points[i].Y);
    }
