        private static T retry<T>(Delegate method, params object[] args)
        {
            for (int i = 0; i <= 3; i++)
            {
                try
                {
                    return (T)method.DynamicInvoke(args);
                }
                catch (Exception ex)
                {
                    if (i == 3)
                    {
                        logMessage(ex.Message);
                    }
                    Console.WriteLine("Retry count " + i);
                    Thread.Sleep(10);
                }
            }
            return default(T);
        }
        private static void retry2(Delegate method, params object[] args)
        {
            for (int i = 0; i <= 3; i++)
            {
                try
                {
                    method.DynamicInvoke(args);
                    break;
                }
                catch (Exception ex)
                {
                    if (i == 3)
                    {
                        logMessage(ex.Message);
                        //return default(T);
                    }
                    Console.WriteLine("Retry count " + i);
                    Thread.Sleep(10);
                }
            }
        }
        static bool isSuccess = true;
        static void logMessage(string msg)
        {
            isSuccess = false;
            Console.WriteLine(msg);
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static void Add2(int a, int b)
        {
            int c = a + b;
            Console.WriteLine(c);
        }
        static void Main(string[] args)
        {
            int d = retry<int>(new Func<int, int, int>(Add), 6, 7.7);
            Console.Write("  " + d + "\n"+isSuccess);
            retry2(new Action<int, int>(Add2), 45, 60);
            Console.ReadKey();
        }
