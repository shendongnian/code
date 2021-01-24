    public static class Tools
    {
        public static void CopyFrom<T>(this T target, T source, params string[] properties)
        {
            ToolsImpl<T>.CopyFrom(target, source, properties);
        }
        private static class ToolsImpl<T>
        {
            private static readonly ConcurrentDictionary<string, Action<T, T>> delegates = new ConcurrentDictionary<string, Action<T, T>>();
            public static void CopyFrom(T target, T source, string[] properties)
            {
                foreach (var property in properties)
                {
                    Action<T, T> del;
                    if (!delegates.TryGetValue(property, out del))
                    {
                        var t2 = Expression.Parameter(typeof(T), "t");
                        var s2 = Expression.Parameter(typeof(T), "s");
                        var prop = typeof(T).GetProperty(property);
                        // The ?. in the source: skip missing properties
                        
                        if (prop == null)
                        {
                            continue;
                        }
                        Expression<Action<T, T>> exp = Expression.Lambda<Action<T, T>>(Expression.Assign(Expression.Property(t2, prop), Expression.Property(s2, prop)), t2, s2);
                        del = exp.Compile();
                        delegates.TryAdd(property, del);
                    }
                    del(target, source);
                }
            }
        }
    }
