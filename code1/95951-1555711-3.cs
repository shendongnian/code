    static object DoWork(object input)
    {
        var casted = input.Cast(new { Name = "" });
        return casted.Name;
    }
    public static class Tools
    {
        public static T Cast<T>(this object target, T example)
        {
            return (T)target;
        }
    }
