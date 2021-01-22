    public static TResult Return<T1, T2, TResult>(this Func<T1, T2, TResult> func, Tuple<T1, T2> parameters) {
        return func(parameters.Item1, parameters.Item2);
    }
    public static TResult Return<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, Tuple<T1, T2, T3> parameters) {
        return func(parameters.Item1, parameters.Item2, parameters.Item3);
    }
