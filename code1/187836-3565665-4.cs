    public void CallAllMethodsInContainer<T>(MyContainer<T> container) where T : IMyInterface
    {
        foreach (IMyInterface myClass in container.Contents)
        {
            myClass.MyMethod();
        }
    }
