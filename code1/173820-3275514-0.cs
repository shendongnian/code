    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            System.Console.WriteLine(x); // 1
            foo(x);
            System.Console.WriteLine(x); // 1
        }
        
        static void foo(int x)
        {
            x++;
        }
    }
