    // if you've already overridden ToString in your MyClass object...
    Console.WriteLine(list.ToDelimitedString());
    // if you don't have a custom ToString method in your MyClass object...
    Console.WriteLine(list.ToDelimitedString(x => x.Property1 + "-" + x.Property2));
    // ...
    public static class MyExtensionMethods
    {
        public static string ToDelimitedString<T>(this IEnumerable<T> source)
        {
            return source.ToDelimitedString(x => x.ToString(),
                CultureInfo.CurrentCulture.TextInfo.ListSeparator);
        }
        public static string ToDelimitedString<T>(
            this IEnumerable<T> source, Func<T, string> converter)
        {
            return source.ToDelimitedString(converter,
                CultureInfo.CurrentCulture.TextInfo.ListSeparator);
        }
        public static string ToDelimitedString<T>(
            this IEnumerable<T> source, string separator)
        {
            return source.ToDelimitedString(x => x.ToString(), separator);
        }
        public static string ToDelimitedString<T>(this IEnumerable<T> source,
            Func<T, string> converter, string separator)
        {
            return string.Join(separator, source.Select(converter).ToArray());
        }
    }
