    class App 
    {
        private static long _Depth = 0;
        // recursive function to blow stack
        private static void GoDeep() 
        {
            if ((++_Depth % 10000) == 0) System.Console.WriteLine("Depth is " +
                _Depth.ToString());
            GoDeep();
        return;
        }
        public static void Main() {
            try 
            {
                GoDeep();
            } 
            finally 
            {
            }
            return;
        }
    }
    editbin /stack:100000,1000 q.exe
    Depth is 10000
    Depth is 20000
    Unhandled Exception: StackOverflowException.
    editbin /stack:1000000,1000 q.exe
    Depth is 10000
    Depth is 20000
    Depth is 30000
    Depth is 40000
    Depth is 50000
    Depth is 60000
    Depth is 70000
    Depth is 80000
    Unhandled Exception: StackOverflowException.
