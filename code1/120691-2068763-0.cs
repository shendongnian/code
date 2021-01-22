    public static string ToCsv<T>(this IEnumerable<T> list, string separator) {
        return String.Join(separator, list.Select(x => x.ToString()).ToArray());
    }
    public static string ToCsv<T>(this IEnumerable<T> list) {
        return list.ToCsv(", ");
    }
