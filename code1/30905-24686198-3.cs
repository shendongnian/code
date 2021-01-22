    using System;
    using System.Collections;
    using System.Collections.Generic;
    public static class KeyEqualityComparer
    {
        public static IEqualityComparer<T> Null<T>()
        {
            return null;
        }
        public static IEqualityComparer<T> EqualityComparerBy<T, K>(
            this IEnumerable<T> source,
            Func<T, K> keyFunc)
        {
            return new KeyEqualityComparer<T, K>(keyFunc);
        }
        public static KeyEqualityComparer<T, K> ThenBy<T, K>(
            this IEqualityComparer<T> equalityComparer,
            Func<T, K> keyFunc)
        {
            return new KeyEqualityComparer<T, K>(keyFunc, equalityComparer);
        }
    }
    public struct KeyEqualityComparer<T, K>: IEqualityComparer<T>
    {
        public KeyEqualityComparer(
            Func<T, K> keyFunc,
            IEqualityComparer<T> equalityComparer = null)
        {
            KeyFunc = keyFunc;
            EqualityComparer = equalityComparer;
        }
        public bool Equals(T x, T y)
        {
            return ((EqualityComparer == null) || EqualityComparer.Equals(x, y)) &&
                    EqualityComparer<K>.Default.Equals(KeyFunc(x), KeyFunc(y));
        }
        public int GetHashCode(T obj)
        {
            var hash = EqualityComparer<K>.Default.GetHashCode(KeyFunc(obj));
            if (EqualityComparer != null)
            {
                var hash2 = EqualityComparer.GetHashCode(obj);
                hash ^= (hash2 << 5) + hash2;
            }
            return hash;
        }
        public readonly Func<T, K> KeyFunc;
        public readonly IEqualityComparer<T> EqualityComparer;
    }
