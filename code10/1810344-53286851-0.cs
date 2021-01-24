    public class Memoized
    {
        // Example with a single parameter. That parameter becomes the key to the dictionary.
        public static Func<T1, TRet> Of<T1, TRet>(Func<T1, TRet> f)
        {
            ConcurrentDictionary<T1, TRet> cache = new ConcurrentDictionary<T1, TRet>();
            return (arg1) => cache.GetOrAdd(arg1, xarg=>f(xarg));
        }
        // Example with two parameters. The key is a tuple, and it must be unpacked before calling func.
        // Three or more parameters generalize from this
        public static Func<T1, T2, TRet> Of<T1, T2, TRet>(Func<T1, T2, TRet> f)
        {
            ConcurrentDictionary<Tuple<T1,T2>, TRet> cache = new ConcurrentDictionary<Tuple<T1, T2>, TRet>();
            return (arg1, arg2) => cache.GetOrAdd(new Tuple<T1,T2>(arg1, arg2), 
                (xarg)=>f(xarg.Item1, xarg.Item2)
                );
        }
    }
