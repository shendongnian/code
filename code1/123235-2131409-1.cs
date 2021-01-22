    private int x;
    public void Test1()
    {
        x = 10;
        Test2(x);
    }
    public void Test2(int y)
    {
        Console.WriteLine("y = " + y);
        x = 5;
        Console.WriteLine("y = " + y);
    }
