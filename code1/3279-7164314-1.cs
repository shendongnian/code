    [Flags]
    public enum TestFlags
    {
        One = 1,
        Two = 2,
        Three = 4,
        Four = 8,
        Five = 16,
        Six = 32,
        Seven = 64,
        Eight = 128,
        Nine = 256,
        Ten = 512
    }
    class Program
    {
        static void Main(string[] args)
        {
            TestFlags f = TestFlags.Five; /* or any other enum */
            bool result = false;
 
            Stopwatch s = Stopwatch.StartNew();
            for (int i = 0; i < 10000000; i++)
            {
                result |= f.HasFlag(TestFlags.Three);
            }
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds); // *4793 ms*
 
            s.Restart();
            for (int i = 0; i < 10000000; i++)
            {
                result |= (f & TestFlags.Three) != 0;
            }
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds); // *27 ms*        
 
            Console.ReadLine();
        }
    }
