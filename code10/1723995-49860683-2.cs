    var example = new Dictionary<string, Func<string, bool>>{ { "foo", Foo } };
    public static bool Foo(string text)
    {
        return true;
    }
    public static bool CallAFunc(string key, string parameter)
    {
        return example[key](parameter);
    }
