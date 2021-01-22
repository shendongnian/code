    private static readonly object FooKey = new object(), BarKey = new object();
    public event EventHandler Foo {
        add {Events.AddHandler(FooKey, value);}
        remove {Events.RemoveHandler(FooKey, value);}
    }
    public event MouseClickEventHandler Bar {
        add {Events.AddHandler(BarKey, value);}
        remove {Events.RemoveHandler(BarKey, value);}
    }
