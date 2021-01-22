    public void MyTest()
    {
        MyClass class = typeof(MyClass).GetConstructor( null )
                                       .Invoke( null );
        ...
    }
