    void StartRecursion(Action<int> func, int x)
    {
        try
        {
            func(x);
        }
        catch (Exception ex)
        {
            throw new RecursionException(path.ToString(), ex);
        }
    }
    void Recursive(int x)
    {
        path.Push(x);
        Recursive(x + 6);
    }
