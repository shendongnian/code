    public void Apply<T1, T2>(MyClass<T1, T2> target)
    {
        GetFunc<T1,T2>().Invoke(target);
    }
    private Action<MyClass<T1,T2>> GetFunc()
    {
        return x => Console.WriteLine(x.ToString());
    }
    
