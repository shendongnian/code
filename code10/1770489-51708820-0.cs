    void SendMyMethod()
    {
        MyMethod2(MyMethod);
    }
    
    async Task<string> MyMethod(int a)
    {
        return "5";
    }
    
    void MyMethod2(Func<int, Task<string>> func)
    {
        func(5);
    }
