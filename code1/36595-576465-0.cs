    public void MyTest()
    {
        MyClass class = typeof(MyClass).GetConstructor( BindingFlags.NonPublic )
                                       .Invoke();
        ...
    }
