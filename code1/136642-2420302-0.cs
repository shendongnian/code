c#
public static class StringExtensions
{
    public static string NullIfEmpty(this string s)
    {
        return string.IsNullOrEmpty(s) ? null : s;
    }
    public static string NullIfWhiteSpace(this string s)
    {
        return string.IsNullOrWhiteSpace(s) ? null : s;
    }
}
