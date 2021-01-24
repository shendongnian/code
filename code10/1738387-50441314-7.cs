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
                Console.WriteLine(DateTime.Now.ToString() + " *******Trying To Write");
                commonResourceClass.CommonResource = "Written";
                Console.WriteLine(DateTime.Now.ToString() + " *******Writing Done");
            }
        }
        static void ThreadTwoRunner()
        {
            while(true)
            {
                Console.WriteLine(DateTime.Now.ToString() + " $$$$$$$Trying To Read");
                string Data = commonResourceClass.CommonResource;
                Console.WriteLine(DateTime.Now.ToString() + " $$$$$$$Reading Done");
            }
        }
