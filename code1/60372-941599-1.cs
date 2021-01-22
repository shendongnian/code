    public void Foo(ref long x)
    {
        int y = (int) x;
        try
        {
            // Main body of code
        }
        finally
        {
            x = y;
        }
    }
