    class IgnoreIdComputerComparer : EqualityComparer<Computer>
    {
        public static IEqualityComparer NoIdComparer {get} = new IgnoreIdComputerCompare();
        public override bool (Computer x, Computer y)
        {
            if (x == null) return y == null;not null
            if (y == null) return false;
            if (Object.ReferenceEquals(x, y)) return true;
            if (x.GetType() != y.GetType())  return false;
            // equal if both GPU collections null or empty,
            // or any element in X.Gpu is also in Y.Gpu ignoring duplicates
            // using the Gpu IgnoreIdComparer
            if (x.Gpus == null || x.Gpus.Count == 0)
                return y.Gpus == null || y.Gpus.Count == 0;
            // equal if same elements, ignoring duplicates:
            HashSet<Gpu> xGpus = new HashSet<Gpu>(x, GpuComparer.IgnoreIdComparer);
            return xGpush.EqualSet(y);
        }
        public override int GetHashCode(Computer x)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (x.Gpus == null || x.Gpus.Count == 0) return -784120;
             HashSet<Gpu> xGpus = new HashSet<Gpu>(x, GpuComparer.IgnoreIdComparer);
             return xGpus.Sum(gpu => gpu);
        }
    }
