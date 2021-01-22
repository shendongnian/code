    public static class ReferenceExtensions
    {
        public static TOut IfNotNull<TIn, TOut>(this TIn v, Func<TIn, TOut> f)
                                        where TIn : class 
                                        where TOut: class
        {
            if (v == null)
                return null;
            return f(v);
        }
    }
