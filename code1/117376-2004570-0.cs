    //Generic Overload 1
    public void DoSomething<T>(T t)
        where T : MyClass
    {
        ...
    }
    //Generic Overload 2
    public void DoSomething<T>(T t)
        where T : List<MyClass>
    {
        ...
    }
