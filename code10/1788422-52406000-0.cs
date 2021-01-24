    struct Stats2
    {
        public float MaxX;
        public float MinX;
        public float MaxY;
        public float MinY;
        public Stats2(float maxX, float minX, float maxY, float minY)
            => (MaxX, MinX, MaxY, MinY) = (maxX, minX, maxY, minY);
    }
    var values = new Vector2[] 
    {
        new Vector2(1,1),
        new Vector2(2,2),
        new Vector2(3,3),
        new Vector2(4,1),
    };
    Vector2[] agg = values.Aggregate(new Stats2(),
        (acc, point) => new Stats2(
                Math.Max(point.X, acc.MaxX),
                Math.Min(point.X, acc.MinX),
                Math.Max(point.Y, acc.MaxY),
                Math.Min(point.Y, acc.MinY)),
        acc => new Vector2[] {
                new Vector2(acc.MinX, acc.MinY),
                new Vector2(acc.MaxX, acc.MaxY),
                new Vector2(acc.MaxX, acc.MinY),
                new Vector2(acc.MinX, acc.MaxY),
        });          
 
