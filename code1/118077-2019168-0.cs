    using System.Collections.Generic;
    using System.Linq;
    class ArrayValueComparer<T> : IEqualityComparer<T[]>
    {
        public bool Equals(T[] x, T[] y)
        {
            return x.SequenceEqual(y, EqualityComparer<T>.Default);
        }
        public int GetHashCode(T[] obj)
        {
            return obj.Aggregate(0, (total, next) => total ^ next.GetHashCode());
        }
    }
    static void Main(string[] args)
    {
        var dict = new Dictionary<int[], bool>(new ArrayValueComparer<int>());
    }
