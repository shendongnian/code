public static string Join&lt;T&gt;(this IEnumerable&lt;T&gt; collection, 
                             string separator, Func&lt;T, object&gt; selector)
{
    if (null == separator)
        throw new ArgumentException("separator");
    if (null == selector)
        throw new ArgumentException("selector");
    Func<T, string> func = item =>
    {
        var @object = selector(item);
        return (null != @object) ? @object.ToString() : string.Empty;
    };
    return string.Join(separator, collection.Select(func).ToArray());
}
