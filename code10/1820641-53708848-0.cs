    public void M1()
    {
        Console.WriteLine("STEP:1");
        var t = M2();
        Console.WriteLine("STEP:3");
        t.ContinueWith(_ =>
        {
            //do nothing
        });
    }
    public Task<string> M2()
    {
        Console.WriteLine("STEP:2");
        Task<string> task = M3();
        return task.ContinueWith(t =>
        {
            Console.WriteLine("STEP:7");
            return t.Result;
        });
    }
    public Task<string> M3()
    {
        Console.WriteLine("STEP:4");
        var rs = Task.Run<string>(() =>
        {
            Thread.Sleep(3000);//simulate some work that takes 3 seconds
            Console.WriteLine("STEP:6");
            return "foo";
        });
        Console.WriteLine("STEP:5");
        return rs.ContinueWith(t => t.Result);
    }
