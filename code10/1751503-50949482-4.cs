    // Simple T[] IEqualityComparer<>
    public sealed class ArrayEqualityComparer<T> : IEqualityComparer<T[]>, IEqualityComparer
    {
        // One instance is more than enough
        public static readonly ArrayEqualityComparer<T> Default = new ArrayEqualityComparer<T>();
        // We lazily define it if necessary
        private readonly IEqualityComparer<T> equalityComparer;
        public ArrayEqualityComparer()
        {
            equalityComparer = EqualityComparer<T>.Default;
        }
        public ArrayEqualityComparer(IEqualityComparer<T> equalityComparer)
        {
            this.equalityComparer = equalityComparer;
        }
        /* IEqualityComparer<T[]> */
        public bool Equals(T[] x, T[] y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return true;
                }
                return false;
            }
            if (y == null)
            {
                return false;
            }
            return EqualsNotNull(x, y);
        }
        public int GetHashCode(T[] obj)
        {
            unchecked
            {
                int hash = 17;
                if (obj != null)
                {
                    // This one will help distinguish between null and empty:
                    // hash(null) == 17, hash(empty) == 17 * 23
                    hash = (hash * 23) + obj.Length;
                    for (int i = 0; i < obj.Length; i++)
                    {
                        hash = (hash * 23) + obj[i].GetHashCode();
                    }
                }
                return hash;
            }
        }
        /* IEqualityComparer */
        bool IEqualityComparer.Equals(object x, object y)
        {
            if (x == y)
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            var x2 = x as T[];
            if (x2 == null)
            {
                throw new ArgumentException("x");
            }
            var y2 = y as T[];
            if (y2 == null)
            {
                throw new ArgumentException("y");
            }
            return EqualsNotNull(x2, y2);
        }
        int IEqualityComparer.GetHashCode(object obj)
        {
            T[] obj2;
            if (obj != null)
            {
                obj2 = obj as T[];
                if (obj2 == null)
                {
                    throw new ArgumentException("obj");
                }
            }
            else
            {
                obj2 = null;
            }
            return GetHashCode(obj2);
        }
        /* Implementation */
        private bool EqualsNotNull(T[] x, T[] y)
        {
            if (x.Length != y.Length)
            {
                return false;
            }
            if (x.Length != 0)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    if (!equalityComparer.Equals(x[i], y[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
