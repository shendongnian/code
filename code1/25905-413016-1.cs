        //mimic fsharp map function (it's select in c#)
        public static IEnumerable<TResult> Map<T, TResult>(this IEnumerable<T> input, Func<T, TResult> func)
        {
            foreach (T val in input)
                yield return func(val);
        }
        //mimic fsharp mapi function (doens't exist in C#, I think)
        public static IEnumerable<TResult> MapI<T, TResult>(this IEnumerable<T> input, Func<int, T, TResult> func)
        {
            int i = 0;
            foreach (T val in input)
            {
                yield return func(i, val);
                i++;
            }
        }
        //mimic fsharp fold function (it's Aggregate in c#)
        public static TResult Fold<T, TResult>(this IEnumerable<T> input, Func<T, TResult, TResult> func, TResult seed)
        {
            TResult ret = seed;
            foreach (T val in input)
                ret = func(val, ret);
            return ret;
        }
        //mimic fsharp foldi function (doens't exist in C#, I think)
        public static TResult FoldI<T, TResult>(this IEnumerable<T> input, Func<int, T, TResult, TResult> func, TResult seed)
        {
            int i = 0;
            TResult ret = seed;
            foreach (T val in input)
            {
                ret = func(i, val, ret);
                i++;
            }
            return ret;
        }
        //mimic fsharp iter function
        public static void Iter<T>(this IEnumerable<T> input, Action<T> action)
        {
            input.ToList().ForEach(action);
        }
