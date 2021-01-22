    public static class FuncHelper
    {
        public static Predicate<T> ToPredicate<T>(this Func<T,bool> f)
        {
            return x => f(x);
        }
    }
