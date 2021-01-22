    // wrapped code to prevent horizontal overflow
    public static void Execute<T1, T2>
    (this Action<T1, T2> action, Tuple<T1, T2> parameters) {
        action(parameters.Item1, parameters.Item2);
    }
