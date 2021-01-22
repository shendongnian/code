        public static IEnumerable<T> Distinct<T,TKey>(this IEnumerable<T> list, Func<T,TKey> lookup) where TKey : struct {
            return list.Distinct(new StructEqualityComparer<T, TKey>(lookup));
        }
        class StructEqualityComparer<T,TKey> : IEqualityComparer<T> where TKey : struct {
            Func<T, TKey> lookup;
            public StructEqualityComparer(Func<T, TKey> lookup) {
                this.lookup = lookup;
            }
            public bool Equals(T x, T y) {
                return lookup(x).Equals(lookup(y));
            }
            public int GetHashCode(T obj) {
                return lookup(obj).GetHashCode();
            }
        }
