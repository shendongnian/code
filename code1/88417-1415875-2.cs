    class Program
    {
        public static int Property { get; set; }
        static void Main(string[] args)
        {
            Property = 3;
            int mainVar = Property;
            for (int run = 0; run < 5; run++)
            {
                Stopwatch s = new Stopwatch();
                Action useProperty = () =>
                {
                    double res;
                    for (int counter = 0; counter < 10000000; counter++)
                        res = Math.Cos(Property);
                };
                s.Start();
                useProperty();
                Console.WriteLine("Property Direct   : {0}", s.Elapsed);
                s.Reset();
                Action useMainVar = () =>
                {
                    double res;
                    for (int counter = 0; counter < 10000000; counter++)
                        res = Math.Cos(mainVar);
                };
                s.Start();
                useProperty();
                Console.WriteLine("Variable from Main: {0}", s.Elapsed);
                s.Reset();
                Action useLocalVariable = () =>
                {
                    int j = Property;
                    double res;
                    for (int counter = 0; counter < 10000000; counter++)
                        res = Math.Cos(j);
                };
                s.Start();
                useLocalVariable();
                Console.WriteLine("Lambda Local      : {0}", s.Elapsed);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
