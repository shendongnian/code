    enum e1
    {
        foo, bar
    }
    
    public void test()
    {
        myFunc(e1.foo); // this needs to be e1.foo or e1.bar - not e1 itself
    }
    
    public void myFunc(Enum e)
    {
        foreach (string item in Enum.GetNames(e.GetType()))
        {
            // Print values
        }
    }
