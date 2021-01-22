    void MyFunc(object obj)
    {
        if (obj != null)
        {
            obj.DoSomething();
        }
        obj.DoSomethingElse();
    }
    void MyFunc(object obj)
    {
        if (obj == null)
            return;
        obj.DoSomething();
        obj.DoSomethingElse();
    }
