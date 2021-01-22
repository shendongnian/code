    public static bool In<T>(this T value, params T[] items) where T : IEquatable<T>
    {
        foreach (var item in items)
        {
            if (value.Equals(item))
            {
                return true;
            }
        }
        return false;
    }
