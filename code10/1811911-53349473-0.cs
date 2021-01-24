    static int prod;
    static void Main(string[] args)
    {
        Thread thread = new Thread(() => Multiply(2, 3));
        thread.Start();
        for (int i = 0; i < 10; i++)
        { // do some other work until thread completes
            Console.Write(i + " ");
           Thread.Sleep(100);
        }
        thread.Join(); // Halt current thread until the other one finishes.
        Console.WriteLine();
        Console.WriteLine("Prod = " + prod); // I expect 6 and it shows 0
        Console.ReadKey(true);
    }
    public static void Multiply(int a, int b)
    {
        Thread.Sleep(2000);
        prod = a * b;
    }
