    public static void Main()
    {
        Action[] actions = new Action[5];
        actions[0] = Method1;
        actions[1] = Method2;
        string checkedValue = "1";
        actions[int.Parse(checkedValue) - 1].Invoke();
    }
    static void Method1()
    {
        Console.WriteLine(1);
    }
    static void Method2()
    { }
