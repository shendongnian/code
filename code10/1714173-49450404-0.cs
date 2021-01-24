    public static class MyFuncConvert
    {
        public static FSharpFunc<T1, FSharpFunc<T2, Unit>> ToFSharpFunc<T1, T2>(Action<T1, T2> action)
        {
            var tupled = FuncConvert.ToFSharpFunc<Tuple<T1, T2>>(
                                      t => action(t.Item1, t.Item2));
            var curried = FuncConvert.FuncFromTupled(tupled);
            return curried;
        }
    }
