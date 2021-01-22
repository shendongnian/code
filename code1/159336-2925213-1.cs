    public static double Average(this IEnumerable<Survey> surveys, Func<Survey, int> selector)
    {
        return surveys.Average(selector);
    }
    public static double Average(this IEnumerable<Survey> surveys, Func<Survey, double> selector)
    {
        return surveys.Average(selector);
    }
