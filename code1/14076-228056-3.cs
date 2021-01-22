    static void Main(string[] args)
    {
        var text = "abcdefghijklmnopqrstuvwxyz";
        // pre-jit
        text = Reverse1(text); 
        text = Reverse2(text);
        // test
        var timer1 = Stopwatch.StartNew();
        for (var i = 0; i < 10000000; i++)
        {
            text = Reverse1(text);
        }
        timer1.Stop();
        Console.WriteLine("First: {0}", timer1.ElapsedMilliseconds);
        var timer2 = Stopwatch.StartNew();
        for (var i = 0; i < 10000000; i++)
        {
            text = Reverse2(text);
        }
        timer2.Stop();
        Console.WriteLine("Second: {0}", timer2.ElapsedMilliseconds);
        Console.ReadLine();
    }
