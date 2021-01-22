    public static class VectorExtensions
    {
        public static Vector<float> ToGenericVector(this Vector2D vector)
        {
            return new Vector<float>(vector.X, vector.Y);
        }
        public static Vector2D ToVector2D(this Vector<float> vector)
        {
            return new Vector2D(vector.X, vector.Y);
        }
    }
