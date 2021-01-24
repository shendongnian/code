    class GpuComparer : EqualityComparer<Gpu>
    {
        public static IEqualityComparer<Gpu> IgnoreIdComparer {get;} = new GpuComparer()
        public override bool Equals(Gpu x, Gpu y)
        {
            if (x == null) return y == null; // true if both null, false if x null but y not null
            if (y == null) return false;     // because x not null
            if (Object.ReferenceEquals(x, y)) return true;
            if (x.GetType() != y.GetType()) return false;
            // if here, we know x and y both not null, and of same type.
            // compare all properties for equality
            return x.Cores == y.Cores;
        }
        public override int GetHasCode(Gpu x)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
             // note: I want a different Hash for x.Cores == null than x.Cores == 0!
             return (x.Cores.HasValue) ? return x.Cores.Value.GetHashCode() : -78546;
             // -78546 is just a value I expect that is not used often as Cores;
        }
    }
