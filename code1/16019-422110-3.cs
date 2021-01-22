    interface IBar { void happy(); }
    class Foo : IBar
    {
        void happy()
        {
            Console.Write("OH MAN I AM SO HAPPY!");
        }
    }
    class Program
    {
        static void Main()
        {
            IBar myBar = new Foo();
            myBar.happy();
        }
    }
