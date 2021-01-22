        public class KeyEqualityComparer<T,U> : IEqualityComparer<T>
        {
            private Func<T,U> GetKey { get; set; }
            public KeyEqualityComparer(Func<T,U> getKey) {
                GetKey = getKey;
            }
            public bool Equals(T x, T y)
            {
                return GetKey(x).Equals(GetKey(y));
            }
            public int GetHashCode(T obj)
            {
                return GetKey(obj).GetHashCode();
            }
        }
