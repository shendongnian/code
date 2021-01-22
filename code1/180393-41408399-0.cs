    public sealed class SelectiveStringComparer : IEqualityComparer<string>
    {
        private readonly string _ignoreChars;
        public SelectiveStringComparer(string ignoreChars = "\r\n")
        {
            _ignoreChars = ignoreChars;
        }
        public bool Equals(string x, string y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (x == null || y == null)
                return false;
            var ix = 0;
            var iy = 0;
            while (true)
            {
                while (ix < x.Length && _ignoreChars.IndexOf(x[ix]) != -1)
                    ix++;
                while (iy < y.Length && _ignoreChars.IndexOf(y[iy]) != -1)
                    iy++;
                if (ix >= x.Length)
                    return iy >= y.Length;
                if (iy >= y.Length)
                    return false;
                if (x[ix] != y[iy])
                    return false;
                ix++;
                iy++;
            }
        }
        public int GetHashCode(string obj)
        {
            throw new NotSupportedException();
        }
    }
