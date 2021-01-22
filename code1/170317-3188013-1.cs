    public static void Delimit<T>(this IEnumerable<T> me, System.IO.TextWriter writer, string delimiter)
    {
        var iter = me.GetEnumerator();
        if (iter.MoveNext())
            writer.Write(iter.Current.ToString());
        while (iter.MoveNext())
        {
            writer.Write(delimiter);
            writer.Write(iter.Current.ToString());
        }
    }
    public static string Delimit<T>(this IEnumerable<T> me, string delimiter)
    {
        var writer = new System.IO.StringWriter();
        me.Delimit(writer, delimiter);
        return writer.ToString();
    }
