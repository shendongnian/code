    namespace Daemon
    {
        using System;
        public class Global
        {
            public static bool BlockLogOut = false;
            static Global()
            {
                throw new Exception();
            }
        }
    }
    namespace ConsoleApplication
    {
        public class Program
        {
            static void Main(string[] args)
            {
                Daemon.Global.BlockLogOut = true; // TypeInitializationException
            }
        }
    }
