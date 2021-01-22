    int i = 1;
    if (Enum.IsDefined(typeof(Foo), i))
    {
        Foo f = (Foo)i;
    }
    else
    {
       // Throw exception, etc.
    }
