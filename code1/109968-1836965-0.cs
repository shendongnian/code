    string result = BuildStrings(new { test.Prop }).First();
    Console.WriteLine(result);
    // or
    string foo = "Test";
    int bar = 42;
    string results = BuildStrings(new { foo, bar, test.Prop });
    foreach (string r in results)
    {
        Console.WriteLine(r);
    }
    // ...
    public static IEnumerable<string> BuildStrings(object source)
    {
        return source.GetType().GetProperties().Select(
            p => string.Format("{0} = '{1}'", p.Name, p.GetValue(source, null)));
    }
