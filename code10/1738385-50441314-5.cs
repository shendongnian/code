        static CommonResourceClass commonResourceClass;
        static void Main(string[] args)
        {
            commonResourceClass = new CommonResourceClass();
            Thread t1 = new Thread(ThreadOneRunner);
            Thread t2 = new Thread(ThreadTwoRunner);
            t1.Start();
            t2.Start();
        }
        static void ThreadOneRunner()
        {
            while(true)
            {
                commonResourceClass.CommonResource = "Written";
                Thread.Sleep(1000);
            }
        }
        static void ThreadTwoRunner()
        {
            while(true)
            {
                Console.WriteLine(commonResourceClass.CommonResource);
                Thread.Sleep(1000);
            }
        }
