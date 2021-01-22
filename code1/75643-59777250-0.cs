        public static void Main()
        {
            List<Task> tasks = new List<Task>();
            Console.WriteLine("Awaiting threads to finished...");
            string par1 = "foo";
            string par2 = "boo";
            int par3 = 3;
            for (int i = 0; i < 1000; i++)
            {
                tasks.Add(Task.Run(() => Calculate(par1, par2, par3))); 
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("All threads finished!");
        }
        static bool Calculate1(string par1, string par2, int par3)
        {
            lock(_locker)
            {
                //...
                return true;
            }
        }
        // if need to lock, use this:
        private static Object _locker = new Object();"
        static bool Calculate2(string par1, string par2, int par3)
        {
            lock(_locker)
            {
                //...
                return true;
            }
        }
