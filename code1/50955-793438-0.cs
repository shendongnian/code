    public static Action<T> Timeout<T>(this Action<T> action, TimeSpan timeSpan);
    public static Action<T1, T2> Timeout<T1, T2>(this Action<T1, T2> action, TimeSpan timeSpan);
    public static Func<T, TResult> Timeout<T, TResult>(this Func<T, TResult> action, TimeSpan timeSpan);
    public static Func<T1, T2, TResult> Timeout<T1, T2, TResult>(this Func<T1, T2, TResult> action, TimeSpan timeSpan);
    /* snip the rest of the Action<...> and Func<...> overloads */
