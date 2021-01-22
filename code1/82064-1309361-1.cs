    public static class FuncExtensions
    {
            public static Func<A, Func<R>> Curry<A, R>(this Func<A, R> f)
            {
                return a => () => f(a);
            }
    }
    
    Func<int, int> f = x => x + 1;
    
    Func<int> curried = f.Curry()(1);
