    class Program
    {
        static void Swap<T>(ref T obj1, ref T obj2)
        {
            var temp = obj1;
            obj1 = obj2;
            obj2 = temp;
        }
        static void Main(string[] args)
        {
            var a = new object();
            var b = new object();
            var s = new Stopwatch();
            Swap(ref a, ref b); // JIT the swap method outside the stopwatch
            s.Restart();
            for (var i = 0; i < 500000000; i++)
            {
                var temp = a;
                a = b;
                b = temp;
            }
            s.Stop();
            Console.WriteLine("Inline temp: " + s.Elapsed);
            s.Restart();
            for (var i = 0; i < 500000000; i++)
            {
                Swap(ref a, ref b);
            }
            s.Stop();
            Console.WriteLine("Call:        " + s.Elapsed);
            s.Restart();
            for (var i = 0; i < 500000000; i++)
            {
                b = Interlocked.Exchange(ref a, b);
            }
            s.Stop();
            Console.WriteLine("Interlocked: " + s.Elapsed);
            Console.ReadKey();
        }
    }
