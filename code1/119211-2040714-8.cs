    public static void Bench(Func<int,int> myFunc, int repeat)
    {
        var R = new System.Random();
        var sw = System.Diagnostics.Stopwatch.StartNew();
        for (int i = 0; i < repeat; i++)
        {
            var ignore = myFunc(R.Next());
        }
        sw.Stop();
        Console.WriteLine("Operation took {0}ms", sw.ElapsedMilliseconds);
    }
