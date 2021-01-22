    public static bool IsBetween(this int value, int min, int max)
    {
        return min <= value && value <= max;
    }
    public static bool IsOutside(this int value, int min, int max)
    {
        return value < min && max < value;
    }
