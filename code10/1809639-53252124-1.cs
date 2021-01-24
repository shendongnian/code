    public void Add()
    {
        int add1 = Pop();
        int add2 = Pop();
        int sum = add1 + add2;
        Console.WriteLine("Sum: {0}", sum);
        Push(sum);
    }
