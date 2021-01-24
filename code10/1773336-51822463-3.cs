    void Method1_Popped()
    {
        string str = client.GetString("http://msdn.microsoft.com");
    }
    void Method2_LeftOnStack()
    {
        string str = client.GetString("http://msdn.microsoft.com");
        Console.WriteLine(str);
    }
    void Method3_Local()
    {
        string str = client.GetString("http://msdn.microsoft.com");
        for(int i = 0;i < 3 ; i++) DoSomethingElse();
        Console.WriteLine(str);
    }
