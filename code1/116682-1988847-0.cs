    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }
        private void Run()
        {
            Lua lua = new Lua();
            var methodInfo = typeof(Program).GetMethod("LUA_GTest", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            lua.RegisterFunction("GTest", this, methodInfo);
            lua.DoString("GTest({{\"3.3\"}})");
        }
        private double LUA_GTest(object d)
        {
            Console.WriteLine("Got {0} - {1}", d.GetType().ToString(), d.ToString());
            while (d is LuaTable)
            {
                d = ((LuaTable)d)[1];
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
