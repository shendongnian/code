    static void TestGC()
    {
            WeakReference w1 = new WeakReference(new Object());
            WeakReference w2 = new WeakReference(new Object());
            GC.Collect();
            Console.WriteLine("o1 is alive: {0}", w1.IsAlive);
            Console.WriteLine("o2 is alive: {0}", w2.IsAlive);
    }
