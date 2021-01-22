    public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
    {
        try
        {
            enumerable.First();
            return false;
        }
        catch (InvalidOperationException)
        {
            return true;
        }
    }
