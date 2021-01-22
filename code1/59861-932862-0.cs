    static void DoesNothing(int a, string b, float? c) { }
    static void Main() {
        Action<int, string, float?> method = DoesNothing;
        int a = 23;
        string b = "abc";
        float? c = null;
        const int LOOP = 5000000;
        Stopwatch watch = Stopwatch.StartNew();
        for (int i = 0; i < LOOP; i++) {
            method(a, b, c);
        }
        watch.Stop();
        Console.WriteLine("Direct: " + watch.ElapsedMilliseconds + "ms");
        watch = Stopwatch.StartNew();
        for (int i = 0; i < LOOP; i++) {
            method.Invoke(a, b, c);
        }
        watch.Stop();
        Console.WriteLine("Invoke: " + watch.ElapsedMilliseconds + "ms");
        object[] args = new object[] { a, b, c };
        watch = Stopwatch.StartNew();
        for (int i = 0; i < LOOP; i++) {
            method.DynamicInvoke(args);
        }
        watch.Stop();
        Console.WriteLine("DynamicInvoke (re-use args): "
             + watch.ElapsedMilliseconds + "ms");
        watch = Stopwatch.StartNew();
        for (int i = 0; i < LOOP; i++) {
            method.DynamicInvoke(a,b,c);
        }
        watch.Stop();
        Console.WriteLine("DynamicInvoke (per-cal args): "
             + watch.ElapsedMilliseconds + "ms");
    }
