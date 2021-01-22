    static void Main(string[] args)
    {
        var func = Memoize<int, int, int>(Func);
        
        Console.WriteLine(func(3)(4));
        Console.WriteLine(func(3)(5));
        Console.WriteLine(func(2)(5));
        Console.WriteLine(func(3)(4));
    }
    //lets pretend this is very-expensive-to-compute function
    private static int Func(int i, int j)
    {
        return i + j;
    }
    private static Func<TArg1, Func<TArg2, TRes>> Memoize<TArg1, TArg2, TRes>(Func<TArg1, TArg2, TRes> func)
    {
         Func<TArg1, Func<TArg2, TRes>> func1 = 
            Memoize((TArg1 arg1) => Memoize((TArg2 arg2) => func(arg1, arg2)));
        return func1;
    }
    private static Func<TArg, TRes> Memoize<TArg, TRes>(Func<TArg, TRes> func)
    {
        var cache = new Dictionary<TArg, TRes>();
        return arg =>
        {
            TRes res;
            if( !cache.TryGetValue(arg, out res) )
            {
                Console.WriteLine("Calculating " + arg.ToString());
                
                res = func(arg);
                cache.Add(arg, res);
            }
            else
            {
                Console.WriteLine("Getting from cache " + arg.ToString());
            }
            
            return res;
        };
    }
