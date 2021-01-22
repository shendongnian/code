    public static class MyExtensions{
    public static int GetLastIndex<T>(this T[] buffer) where T: Integer
    {
        return buffer.GetUpperBound(0);
    }}
