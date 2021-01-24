    struct Stats2
    {
        public readonly float MaxX;
        public readonly float MinX;
        public readonly float MaxY;
        public readonly float MinY;
        public Stats2(float maxX, float minX, float maxY, float minY)
            => (MaxX, MinX, MaxY, MinY) = (maxX, minX, maxY, minY);
        public static Stats2 Apply(Stats2 acc,Vector2 point) =>
            new Stats2(  Math.Max(point.X, acc.MaxX),
                         Math.Min(point.X, acc.MinX),
                         Math.Max(point.Y, acc.MaxY),
                         Math.Min(point.Y, acc.MinY));
        public static Stats2 Apply(Stats2 acc,Vector3 point) =>
            new Stats2(  Math.Max(point.X, acc.MaxX),
                         Math.Min(point.X, acc.MinX),
                         Math.Max(point.Y, acc.MaxY),
                         Math.Min(point.Y, acc.MinY));
    }
