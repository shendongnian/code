    public void DoSomething<T>(T value)  
    {
        if (value is MyClass mc)
        {
            ...
        }
        else if (value is List<MyClass> lmc)
        {
            ...
        }
    }
