    /// <summary>
    /// An <see cref="IEqualityComparer{T}"/> that compares the values of each public property.
    /// </summary>
    /// <typeparam name="T"> The type to compare. </typeparam>
    public class PropertyEqualityComparer<T> : IEqualityComparer<T>
    {
        // http://stackoverflow.com/questions/986572/hows-to-quick-check-if-data-transfer-two-objects-have-equal-properties-in-c/986617#986617
        static class EqualityCache
        {
            internal static readonly Func<T, T, bool> Compare;
            static EqualityCache()
            {
                var props = typeof(T).GetProperties();
                if (props.Length == 0)
                {
                    Compare = delegate { return true; };
                    return;
                }
                var x = Expression.Parameter(typeof(T), "x");
                var y = Expression.Parameter(typeof(T), "y");
                Expression body = null;
                for (int i = 0; i < props.Length; i++)
                {
                    var propEqual = Expression.Equal(
                        Expression.Property(x, props[i]),
                        Expression.Property(y, props[i]));
                    if (body == null)
                    {
                        body = propEqual;
                    }
                    else
                    {
                        body = Expression.AndAlso(body, propEqual);
                    }
                }
                Compare = Expression.Lambda<Func<T, T, bool>>(body, x, y).Compile();
            }
        }
        /// <inheritdoc/>
        public bool Equals(T x, T y)
        {
            return EqualityCache.Compare(x, y);
        }
        static class HashCodeCache
        {
            internal static readonly Func<T, int> Hasher;
            static HashCodeCache()
            {
                var props = typeof(T).GetProperties();
                if (props.Length == 0)
                {
                    Hasher = delegate { return 0; };
                    return;
                }
                var x = Expression.Parameter(typeof(T), "x");
                Expression body = null;
                for (int i = 0; i < props.Length; i++)
                {
                    var prop = Expression.Property(x, props[i]);
                    var type = props[i].PropertyType;
                    var isNull = type.IsValueType ? (Expression)Expression.Constant(false, typeof(bool)) : Expression.Equal(prop, Expression.Constant(null, type));
                    var hashCodeFunc = type.GetMethod("GetHashCode", BindingFlags.Instance | BindingFlags.Public);
                    var getHashCode = Expression.Call(prop, hashCodeFunc);
                    var hashCode = Expression.Condition(isNull, Expression.Constant(0, typeof(int)), getHashCode);
                    if (body == null)
                    {
                        body = hashCode;
                    }
                    else
                    {
                        body = Expression.ExclusiveOr(Expression.Multiply(body, Expression.Constant(typeof(T).AssemblyQualifiedName.GetHashCode(), typeof(int))), hashCode);
                    }
                }
                Hasher = Expression.Lambda<Func<T, int>>(body, x).Compile();
            }
        }
        /// <inheritdoc/>
        public int GetHashCode(T obj)
        {
            return HashCodeCache.Hasher(obj);
        }
    }
