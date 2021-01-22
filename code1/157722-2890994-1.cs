    delegate int OtherDel(int x);
    public static void Main()
    {
        int y = 4;
        OtherDel del = x =>
        {
            Console.WriteLine("{0}", x);
            return x;
        };
        int result = del(y);
    }
