    private static List<T> ConvertArray<T>(Array input)
    {
        return input.Cast<T>().ToList(); // Using LINQ for simplicity
    }
    public static object GetDeserializedObject(object obj, Type targetType)
    {
        if (obj is Array)
        {
            MethodInfo convertMethod = typeof(...).GetMethod("ConvertArray",
                BindingFlags.NonPublic | BindingFlags.Static);
            MethodInfo generic = convertMethod.MakeGenericMethod(new[] {targetType});
            return generic.Invoke(null, new object[] { obj });
        }
        return obj;
    }
