    class Test
    {
        public const decimal x = 0.2m;
        public readonly decimal y = 0.2m;
        public void Method1(in decimal x)
        {
            Thread.MemoryBarrier();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Test();
            var sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < 100000000; i++)
            {
                t.Method1(in t.y);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);
            sw.Restart();
            for (var i = 0; i < 100000000; i++)
            {
                t.Method1(Test.x);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);
            Console.ReadLine();
         } 
    }
