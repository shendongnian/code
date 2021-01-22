    SomeObject foo = new SomeObject();
    for (int i=0; i < 100000; i++)
    {
        if (i == 5)
        {
            foo.DoSomething();
            // We're not going to need it again, but the JIT
            // wouldn't spot that
            foo = null;
        }
        else
        {
            // Some other code 
        }
    }
