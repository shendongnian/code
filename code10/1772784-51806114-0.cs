        private const double Epsilon = 0.000001d;
        public static Vector3? GetTimeAndUvCoord(Vector3 rayOrigin, Vector3 rayDirection, Vector3 vert0, Vector3 vert1, Vector3 vert2)
        {
            var edge1 = vert1 - vert0;
            var edge2 = vert2 - vert0;
            var pvec = Cross(rayDirection, edge2);
            var det = Dot(edge1, pvec);
            if (det > -Epsilon && det < Epsilon)
            {
                return null;
            }
            var invDet = 1d / det;
            var tvec = rayOrigin - vert0;
            var u = Dot(tvec, pvec) * invDet;
            if (u < 0 || u > 1)
            {
                return null;
            }
            var qvec = Cross(tvec, edge1);
            var v = Dot(rayDirection, qvec) * invDet;
            if (v < 0 || u + v > 1)
            {
                return null;
            }
            var t = Dot(edge2, qvec) * invDet;
            return new Vector3((float)t, (float)u, (float)v);
        }
        private static double Dot(Vector3 v1, Vector3 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }
        private static Vector3 Cross(Vector3 v1, Vector3 v2)
        {
            Vector3 dest;
            dest.X = v1.Y * v2.Z - v1.Z * v2.Y;
            dest.Y = v1.Z * v2.X - v1.X * v2.Z;
            dest.Z = v1.X * v2.Y - v1.Y * v2.X;
            return dest;
        }
        public static Vector3 GetTrilinearCoordinateOfTheHit(float t, Vector3 rayOrigin, Vector3 rayDirection)
        {
            return rayDirection * t + rayOrigin;
        }
