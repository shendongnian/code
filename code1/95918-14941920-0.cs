    public static void Main()
    {
        int data= 0;
        
        Thread t1 = new Thread(()=> add1(ref data));
        Thread t2 = new Thread(() => add2(ref data));
        t1.Start();
        t2.Start();
    }
    static void add1(ref int x)
    {
        object lockthis = new object();
        lock (lockthis)
        {
            for (int i = 0; i < 30; i++)
            {
                x += 1;
                Console.WriteLine("add1 " + x);
            }
        }
    }
    static void add2(ref int x)
    {
        object lockthis = new object();
        lock (lockthis)
        {
            for (int i = 0; i < 30; i++)
            {
                x += 3;
                Console.WriteLine("add2 " + x);
            }
        }
    }
}
