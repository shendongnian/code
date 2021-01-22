    class Program
    {
        static void Main()
        {
            StaticMethod(); // JIT
            Program p = new Program();
            p.InstanceMethod(); // JIT
    
            const int LOOP = 50000000; // 50M
            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < LOOP; i++) StaticMethod();
            watch.Stop();
            Console.WriteLine("static: " + watch.ElapsedMilliseconds + "ms");
            
            watch = Stopwatch.StartNew();
            for (int i = 0; i < LOOP; i++) p.InstanceMethod();
            watch.Stop();
            Console.WriteLine("instance: " + watch.ElapsedMilliseconds + "ms");
        }
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        void InstanceMethod() { }
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        static void StaticMethod() { }
    }
