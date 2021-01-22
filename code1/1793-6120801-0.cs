    try
    {
        if (condition)
        {
            Something(new delegate
            {
                SomeCall(a, b);
            });
        }
        else
        {
            SomethingElse();
            Foobar(foo, bar);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Okay, you got me");
    }
