    class Plane {
        Vector3 a, b, c;
        public Vector3 Normal {
            get {
                var dir = Vector3.Cross(b - a, c - a);
                var norm = Vector3.Normalize(dir);
                return norm;
            }
        }
    }
