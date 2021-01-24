    class Program
    {
        private static Thread[] threads = new Thread[3];
        private static Semaphore sem = new Semaphore(1, 1);
        private static List<string> messagesList = new List<string>();
        private static readonly object _kilit = new object();
        static void Main(string[] args)
        {
            Thread addData = new Thread(AddData);
            addData.Start();
            for (int j = 0; j < 3; j++)
            {
                threads[j] = new Thread(AddComma);
                threads[j].Name = "thread_" + j;
                threads[j].Start();
            }
        }
        public static void AddData()
        {
            for (int i = 0; i < 10; i++)
            {
                messagesList.Add("data");
                messagesList.Add("data");
                Thread.Sleep(1000);
            }
        }
        public static void AddComma()
        {
            
            while (true)
            {
                sem.WaitOne();
                if (messagesList.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(Thread.CurrentThread.Name + "Entering to Critical section");
                    int averageIndex = messagesList[0].ToString().Length / 2; // Here is the error
                    string msg = messagesList[0].ToString().Substring(0, averageIndex) + "," + messagesList[0].ToString().Substring(averageIndex);
                    Console.WriteLine(msg);
                    messagesList.RemoveAt(0);
                    Console.WriteLine(Thread.CurrentThread.Name + "Exiting from Critical Section");
                }
                sem.Release();
            }
        }
    }
