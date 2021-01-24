    class MyComparer : IEqualityComparer<LatLng[]>
    {
        public bool Equals(LatLng[] x, LatLng[y])
        {
            return a.SequenceEquals(y, new MyLatLngComparer());
        }
        public int GetHashCode(LatLng[] x)
        {
            return x.First().GetHashCode();
        }
    }
