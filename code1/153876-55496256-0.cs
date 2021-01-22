    readonly static object[] x = new object[2] { true, false };
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            x[0] = false;
            x[1] = true;
            Console.WriteLine("{0} {1}", x[0], x[1]); //prints "false true"
            Console.ReadLine();
        }
