    public void Test1(MyClass c)
    {
        c.SomeEvent += new EventHandler(MyHandlerMethod);
        // Do some work
        c.SomeEvent -= new EventHandler(MyHandlerMethod);
    }
