    void Main()
    {
        GetTheID = () => GetMyId().Result;
        Console.WriteLine(GetTheID.Invoke());
    }
