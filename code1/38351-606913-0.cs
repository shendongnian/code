    public void Go<T>(IEnumerable<T> interfaceList)
        where T : IB
    {
        foreach (IB ibby in interfaceList)
        {
            Console.WriteLine("Here");
        }
    }
