    Testing with exception: 2430985 ticks
    Testing with reflection: 28587 ticks
------
    void Main()
    {
        var random = new Random(Environment.TickCount);
    
        dynamic test = new Test();
    
        var sw = new Stopwatch();
    
        sw.Start();
    
        for (int i = 0; i < 100000; i++)
        {
            TestWithException(test, FlipCoin(random));
        }
    
        sw.Stop();
    
        Console.WriteLine("Testing with exception: " + sw.ElapsedTicks.ToString() + " ticks");
    
        sw.Restart();
    
        for (int i = 0; i < 10000; i++)
        {
            TestWithReflection(test, FlipCoin(random));
        }
    
        sw.Stop();
    
        Console.WriteLine("Testing with reflection: " + sw.ElapsedTicks.ToString() + " ticks");
    }
    
    class Test
    {
        public bool Exists { get { return true; } }
    }
    
    bool FlipCoin(Random random)
    {
        return random.Next(2) == 0;
    }
    
    bool TestWithException(dynamic d, bool useExisting)
    {
        try
        {
            bool result = useExisting ? d.Exists : d.DoesntExist;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    
    bool TestWithReflection(dynamic d, bool useExisting)
    {
        Type type = d.GetType();
    
        return type.GetProperties().Any(p => p.Name.Equals(useExisting ? "Exists" : "DoesntExist"));
    }
