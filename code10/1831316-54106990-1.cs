    public static void Main()
    {
        Action[] actions = new Action[5];
        actions[0] = ()=> { Console.WriteLine(1); };
        actions[1] = ()=> { Console.WriteLine(2); };
        string checkedValue = "1";
        actions[int.Parse(checkedValue) - 1].Invoke();
    }
