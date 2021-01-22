    /// <summary>
    /// C# implementation of Visual Basics With statement
    /// </summary>
    public static void With<T>(this T _object, Action<T> _action)
    {
        _action(_object);
    }
