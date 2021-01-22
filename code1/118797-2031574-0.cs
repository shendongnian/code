public static string ToDelimitedString&lt;T&gt;(this IEnumerable&lt;T&gt; items, string delimiter)
{
    StringBuilder joinedItems = new StringBuilder();
    foreach (T item in items)
    {
        if (joinedItems.Length > 0)
            joinedItems.Append(delimiter);
        joinedItems.Append(item);
    }
    return joinedItems.ToString();
}
For your list it becomes: l.ToDelimitedString(",")
