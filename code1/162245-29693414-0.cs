    dynamic test = new System.Dynamic.ExpandoObject();
    test.foo = "bar";
    if (((IDictionary<string, object>)test).ContainsKey("foo"))
    {
        Console.WriteLine(test.foo);
    }
