    void Main()
    {
        GetTheID = () => GetMyId().GetAwaiter().GetResult();
        Console.WriteLine(GetTheID);
    }
