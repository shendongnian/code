    public unsafe static void  Main()
    {
       var a = 5;
       var b = 6;
       Swap(&a, &b);
       Console.WriteLine("a={0},b={1}", a, b);
       Console.ReadKey();
    }
