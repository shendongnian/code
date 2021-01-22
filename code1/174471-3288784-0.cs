    class Program
    {
        static void Main(string[] args)
        {
            M1("test");
            M2("test", "test2");
            M3("test", "test2", 1);
            Console.ReadKey();
        }
        static void M1(string p1)
        {
            Log(MethodBase.GetCurrentMethod());
        }
        static void M2(string p1, string p2)
        {
            Log(MethodBase.GetCurrentMethod());
        }
        static void M3(string p1, string p2, int p3)
        {
            Log(MethodBase.GetCurrentMethod());
        }
        static void Log(MethodBase method)
        {
            Console.WriteLine("Method: {0}", method.Name);
            foreach (ParameterInfo param in method.GetParameters())
            {
                Console.WriteLine("ParameterName: {0}, ParameterType: {1}", param.Name, param.ParameterType.Name);
            }
        }
    }
