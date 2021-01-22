Main.cs
    partial class Program
    {
        private static void Main()
        {
            A();
            B();
        }
    }
fileA.cs
    partial class Program
    {
        private static void A() => Console.WriteLine("A");
    }
fileB.cs
    partial class Program
    {
        private static void B() => Console.WriteLine("B");
    }
