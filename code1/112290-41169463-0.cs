    public sealed class ReferenceEqualityComparer : IEqualityComparer, IEqualityComparer<object>
    {
        public static readonly ReferenceEqualityComparer Default = new ReferenceEqualityComparer();
        bool IEqualityComparer<object>.Equals(object x, object y) => ReferenceEquals(x, y);
        bool IEqualityComparer.Equals(object x, object y) => ReferenceEquals(x, y);
        public int GetHashCode(object obj) => RuntimeHelpers.GetHashCode(obj);
    }
