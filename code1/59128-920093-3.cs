    struct Vec2 {
        public float X { get; private set; }
        public float Y { get; private set; }
        public Vec2(float x, float y) {
           X = x;
           Y = y;
        }
        public Vec2 Add(Vec2 other) {
           return new Vec2(X + other.X, Y + other.Y);
        }
    }
