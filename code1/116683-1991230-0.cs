        class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }
        private void Run()
        {
            JintEngine engine = new JintEngine();
            engine.SetFunction("GTest", new Jint.Delegates.Func<object, double>(LUA_GTest));
            engine.Run("GTest([['3,3']])");
        }
        private double LUA_GTest(object d)
        {
            Console.WriteLine("Got {0} - {1}", d.GetType().ToString(), d.ToString());
            while (d is ArrayList)
            {
                d = ((ArrayList)d)[0];
                Console.WriteLine("Got {0} - {1}", d.GetType().ToString(), d.ToString());
            }
            if (d is string)
            {
                d = double.Parse((string)d);
                Console.WriteLine("Got {0} - {1}", d.GetType().ToString(), d.ToString());
            }
            if (d is double)
                return (double)d * 2;
            return 0;
        }
    }
