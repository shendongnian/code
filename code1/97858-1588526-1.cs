    void StartRecursion(int x)
    {
        try
        {
            path.Clear();
            Recursive(x);
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
        path.Pop();
    }
    void Main()
    {
        StartRecursion(100);
    }
