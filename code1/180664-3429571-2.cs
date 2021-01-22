    public void DoSomeWorkWith(Foo x)
    {
        var s = CreateStackWithInitialItem(new {level = 0, item = x});
        while(s.Any())
        {
            ...
        }
    }
