    public static T ToEnum<T>(this string value)
    {
        return (T) Enum.Parse(typeof(T), value, true);
    }
    StatusEnum MyStatus = "Active".ToEnum<StatusEnum>();
