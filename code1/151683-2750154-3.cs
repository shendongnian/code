    public void Test2(MyClass c)
    {
        c.SomeEvent += MyHandlerMethod;
        // Do some work
        c.SomeEvent -= MyHandlerMethod;
    }
