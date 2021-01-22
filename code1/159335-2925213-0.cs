    public static double Average(this IEnumerable<Survey> surveys, Func<Survey, int> selector)
    {
        return surveys.Select(selector).Average();
    }
    public static double Average(this IEnumerable<Survey> surveys, Func<Survey, double> selector)
    {
        return surveys.Select(selector).Average();
    }
