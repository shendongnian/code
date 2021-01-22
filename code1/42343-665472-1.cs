    public static bool HasFive<T>(this IEnumerable<T> subjects)
    {
        subjects.ThrowIfNull("subjects");    
        return subjects.Count() == 5;
    }
