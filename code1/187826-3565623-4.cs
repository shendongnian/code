    public void CallAllMethodsInContainer<T>(MyContainer<T> container) where T : IMyInterface
    {
        foreach (T myClass in container.Contents)
        {
            myClass.MyMethod();
        }
    }
