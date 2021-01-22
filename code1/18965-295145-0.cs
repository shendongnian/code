    public event FooHandler Foo
    {
        add
        {
            c.Foo += value;
        }
        remove
        {
            c.Foo -= value;
        }
    }
