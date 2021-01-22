    public void HandleAnonymousTypeAsParameter(Object o)
    {
        var anonymousType = o.ToAnonymousType(new
        {
            Id = new Int32(),
            Foo = new String(),
            Bar = new String()
        });
        // You can do this in even less characters:
        var anonymousType = o.ToAnonymousType(new
        {
            Id = 0,
            Foo = "",
            Bar = ""
        });
    }
    
    HandleAnonymousTypeAsParameter(new
    {
        Id = 1,
        Foo = "foo",
        Bar = "bar"
    });
