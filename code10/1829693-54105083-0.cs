    private class CustomEqualityComparer<T> : IEqualityComparer<T>
        {
            private readonly List<string> _columns;
            private readonly bool _enableHashCode;
            private readonly ConcurrentDictionary<string, Func<T, object>> _cache;
            public CustomEqualityComparer(List<string> columns, ConcurrentDictionary<string, Func<T, object>> cache, bool enableHashCode = false)
            {
                _columns = columns;
                _enableHashCode = enableHashCode;
                _cache = cache;
            }
            public bool Equals(T x, T y)
            {
                for (var i = 0; i < _columns.Count; i++)
                {
                    object value1 = GetValue(x, _columns[i], _cache);
                    object value2 = GetValue(y, _columns[i], _cache);
                    if (!value1.Equals(value2)) return false;
                }
                return true;
            }
            public int GetHashCode(T obj)
            {
                return _enableHashCode ? GetHashCode(obj, _columns, _cache) : 0;
            }
            private object GetValue(object item, string propertyName, ConcurrentDictionary<string, Func<T, object>> cache)
            {
                if (!cache.TryGetValue(propertyName, out Func<T, object> propertyResolver))
                {
                    ParameterExpression arg = Expression.Parameter(item.GetType(), "x");
                    Expression expr = Expression.Property(arg, propertyName);
                    UnaryExpression unaryExpression = Expression.Convert(expr, typeof(object));
                    propertyResolver = Expression.Lambda<Func<T, object>>(unaryExpression, arg).Compile();
                    cache.TryAdd(propertyName, propertyResolver);
                }
                return propertyResolver((T)item);
            }
            private int GetHashCode(T obj, List<string> columns, ConcurrentDictionary<string, Func<T, object>> cache)
            {
                unchecked
                {
                    var hashCode = 17;
                    for (var i = 0; i < columns.Count; i++)
                    {
                        object value = GetValue(obj, columns[i], cache);
                        var tempHashCode = value == null ? 0 : value.GetHashCode();
                        hashCode = hashCode * 23 + tempHashCode;
                    }
                    return hashCode;
                }
            }
        }
