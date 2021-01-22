    class Point : IEquatable<Point> {
        public int X { get; }
        public int Y { get; }
        public Point(int x = 0, int y = 0) { X = x; Y = y; }
        public bool Equals(Point other) {
            if (other is null) return false;
            return X.Equals(other.X) && Y.Equals(other.Y);
        }
        public override bool Equals(object obj) {
            return Equals(obj as Point);
        }
        public static bool operator ==(Point lhs, Point rhs) {
            return object.Equals(lhs, rhs);
        }
        public static bool operator !=(Point lhs, Point rhs) {
            return ! (lhs == rhs);
        }
        public override int GetHashCode() {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
