    public static void Execute<T1, T2>(this Action<T1, T2> action, Tuple<T1, T2> parameters) {
        action(parameters.Item1, parameters.Item2);
    }
    public static void Execute<T1, T2, T3>(this Action<T1, T2, T3> action, Tuple<T1, T2, T3> parameters) {
        action(parameters.Item1, parameters.Item2, parameters.Item3);
    }
