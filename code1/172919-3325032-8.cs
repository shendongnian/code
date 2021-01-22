    static void Main()
    {
     Continuation c = new Continuation();
     c.Mark();
     int foo = 123;
     int val = c.Store(0);
     Console.WriteLine("{0} {1}", val, foo);
     foo = 321;
     if (val < 5)
         c.Restore(val + 1);
    }
