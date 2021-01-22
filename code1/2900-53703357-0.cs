    public static string DoSomething(this int input, ...) => DoSomethingHelper(input, ...);
    public static string DoSomething(this decimal input, ...) => DoSomethingHelper(input, ...);
    public static string DoSomething(this double input, ...) => DoSomethingHelper(input, ...);
    public static string DoSomething(this string input, ...) => DoSomethingHelper(input, ...);
    
    private static string DoSomethingHelper<T>(this T input, ....)
    {
        // complex logic
    }
