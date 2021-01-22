        public static Func<T, R> TryCoalesce<T, R>(this Func<T, R> f, R coalesce)
        {
            return x =>
                {
                    try
                    {
                        return f(x);
                    }
                    catch
                    {
                        return coalesce;
                    }
                };
        }
        public static TResult TryCoalesce<T, TResult>(this Func<T, TResult> f, T p, TResult coalesce)
        {
            return f.TryCoalesce(coalesce)(p);
        }
