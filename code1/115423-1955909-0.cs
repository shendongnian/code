    static void Main(string[] args)
    {
        Dictionary<string, Action<MyClass>> myActions =
            new Dictionary<string,Action<MyClass>>();
        myActions.Add("Command1",
           delegate { MyClass.DoCommand1("message1"); });
        myActions.Add("Command2",
           delegate { MyClass.DoCommand1("message2"); });
        myActions["Command1"]();
    }
