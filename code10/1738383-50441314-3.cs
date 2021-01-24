        static void Main(string[] args)
        {
            CommonResourceClass.InitLockObj();
            Thread t1 = new Thread(ThreadOneRunner);
            Thread t2 = new Thread(ThreadTwoRunner);
            t1.Start();
            t2.Start();
        }
        static void ThreadOneRunner()
        {
            while(true)
            {
                CommonResourceClass.CommonResource = "Written";
                Thread.Sleep(1000);
            }
        }
        static void ThreadTwoRunner()
        {
            while(true)
            {
                Console.WriteLine(CommonResourceClass.CommonResource);
                Thread.Sleep(1000);
            }
        }
