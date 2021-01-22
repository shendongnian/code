    static void Main()
    {
        IEnumerable data = new[] { new { Foo = "abc" }, new { Foo = "def" }, new { Foo = "ghi" } };
        var typed = data.Cast(() => new { Foo = "never used" });
        foreach (var item in typed)
        {
            Console.WriteLine(item.Foo);
        }
    }
    // note that the template is not used, and we never need to pass one in...
    public static IEnumerable<T> Cast<T>(this IEnumerable source, Func<T> template)
    {
        return Enumerable.Cast<T>(source);
    }
