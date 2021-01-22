Main.cs
    partial class Program
    {
        static void Main()
        {
            A();
            B();
        }
    }
fileA.cs
    using System;
    partial class Program
    {
        static void A()
        {
            Console.WriteLine("A");
        }
    }
fileB.cs
    using System;
    partial class Program
    {
        static void B()
        {
            Console.WriteLine("B");
        }
    }
