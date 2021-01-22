    public void myFunc(Enum e)
    {
        foreach (var name in Enum.GetNames(e.GetTye()))
        {
            Console.WriteLine(name);
        }
    }
