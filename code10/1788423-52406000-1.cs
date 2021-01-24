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
