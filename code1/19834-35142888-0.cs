    class Program
    {
      static void Main(string[] args)
      {
        const int iterations = 100;
        Console.WriteLine($"Signed:      {Iterate(TestSigned, iterations)}");
        Console.WriteLine($"Unsigned:    {Iterate(TestUnsigned, iterations)}");
        Console.Read();
      }
    
      private static void TestUnsigned()
      {
        uint accumulator = 0;
        var max = (uint)Int32.MaxValue;
        for (uint i = 0; i < max; i++) ++accumulator;
      }
    
      static void TestSigned()
      {
        int accumulator = 0;
        var max = Int32.MaxValue;
        for (int i = 0; i < max; i++) ++accumulator;
      }
    
      static TimeSpan Iterate(Action action, int count)
      {
        var elapsed = TimeSpan.Zero;
        for (int i = 0; i < count; i++)
          elapsed += Time(action);
        return new TimeSpan(elapsed.Ticks / count);
      }
    
      static TimeSpan Time(Action action)
      {
        var sw = new Stopwatch();
        sw.Start();
        action();
        sw.Stop();
        return sw.Elapsed;
      }
    }
