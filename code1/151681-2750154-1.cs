    public void Test1(MyClass c)
    {
        c.SomeEvent += MyHandlerMethod;
        // Do some work
        c.SomeEvent -= MyHandlerMethod;
    }
