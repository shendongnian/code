    class MyLatLngComparer : IEqualityComparer<LatLng>
    {
        private readonly double Tolerance;
        public MyLatLngComparer(double tolerance) { this.Tolerance = tolerance ;}
        public bool Equals(LatLng x, LatLng y)
        {
            return Math.Abs(x - y) <= Tolerance;
        }
        public int GetHashCode(LatLng x)
        {
            return x.GetHashCode();
        }
    }
