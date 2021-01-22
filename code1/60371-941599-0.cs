    public void Foo(ref int x)
    {
        // Here's the body I *really* want
    }
    public void Foo(ref long x)
    {
        // But I'm forced to use this signature for whatever
        // reasons. Oh well. This hack isn't an *exact* mimic
        // of ref behaviour, but it's close.
        // TODO: Decide an overflow policy
        int tmp = (int) x;
        Foo(ref tmp);
        x = tmp;
    }
