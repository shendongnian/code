    public static class ThreadSafeConsole
    {
        private static object _lockObject = new object();
        public static void WriteLine(string str)
        {
            lock (_lockObject) 
            {
                Console.WriteLine(str);
            }
        }
    }
