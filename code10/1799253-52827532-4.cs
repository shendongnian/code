    class Program
    {
        static void Main(string[] args)
        {
            //float + integer
            Console.WriteLine(1f / 3 + 1 / 3);
    
            //double + integer
            Console.WriteLine(1d / 3 + 1 / 3);
    
            //double + float
            Console.WriteLine(1d / 3 + 1 / 3f);
    
            //decimal + integer
            Console.WriteLine(1m / 3 + 1 / 3);
    
            //decimal + decimal
            Console.WriteLine(1m / 3 + 1 / 3m);
    
            Console.ReadKey();
        }
        // OUTPUT
        // 0.3333333
        // 0.333333333333333
        // 0.666666676600774
        // 0.3333333333333333333333333333
        // 0.6666666666666666666666666666
    }
