    public async Task DoStuffAsync()
    {
        var tasks = { dependency.FooAsync(), dependency.BarAsync() };
        reutrn Task.WhenAll(tasks.Skip(1));
        // Test fail with message:
        // Expected subject to be a collection with 2 item(s), but {"Bar"}
        // contains 1 item(s) less than {"Foo", "Bar"}.        
    }
