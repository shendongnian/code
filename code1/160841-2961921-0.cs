    public static bool Is<T>(this string input)
    {
        var type = typeof (T);
        var temp = default(T);
        var method = type.GetMethod(
            "TryParse",
            new[]
                {
                    typeof (string),
                    Type.GetType(string.Format("{0}&", type.FullName))
                });
        return (bool) method.Invoke(null, new object[] {input, temp});
    }
