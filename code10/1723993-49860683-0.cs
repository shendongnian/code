    var example = new Dictionary<string, Action<string>>{ { "foo", Foo } };
    public static void Foo(string text) {}
    public static void CallAnAction(string key, string parameter)
    {
        example[key](parameter);
    }
