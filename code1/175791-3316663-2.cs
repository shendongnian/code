    ///Base foo method
    public void DoFoo(int a, long b, string c)
    {
       //Do something
    }  
    /// Foo with 2 params only
    public void DoFoo(int a, long b)
    {
        /// ....
        DoFoo(a, b, "Hello");
    }
    public void DoFoo(int a)
    {
        ///....
        DoFoo(a, 23, "Hello");
    }
    
    .....
