    MyData foo = new MyData();
    foo.Num = 1;
    
    MyData bar = new MyData();
    bar.Num = 2;
    
    Console.WriteLine(foo.Num); // num = 1
    Test(bar, foo);
    Console.WriteLine(foo.Num); // num still equals 1
    
    public static void Test(MyData src, MyData dest)
    {
        // dest.Num = 1 here
        dest = src;
        // dest.Num = 2 now
    }
