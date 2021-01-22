    using System;
    class Base
    {
    public Base()
    {
        Console.WriteLine("BASE 1");
    }
    public Base(int x)
    {
        Console.WriteLine("BASE 2");
    }
    }
    class Derived : Base
    {
    public Derived():base(10)
    {
        Console.WriteLine("DERIVED CLASS");
    }
    }
    class MyClient
    {
    public static void Main()
    {
        Derived d1 = new Derived();
    }
    }
