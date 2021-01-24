    namespace Vectors
    {
        public static class VectorMath
        {
            public static Vector Pow(Vector v, int exponent)
            {
                return new Vector(v.Select(n => Math.Pow(n, exponent)));
            }
        }
    }
