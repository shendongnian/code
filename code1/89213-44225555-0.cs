        // The Dummy Lock
        public static List<int> DummyLock = new List<int>();
        static void Main(string[] args)
        {
            MultipleFileWriting();
            Console.ReadLine();
        }
        // Create two threads
        private static void MultipleFileWriting()
        {
            BackgroundWorker thread1 = new BackgroundWorker();
            BackgroundWorker thread2 = new BackgroundWorker();
            thread1.DoWork += Thread1_DoWork;
            thread2.DoWork += Thread2_DoWork;
            thread1.RunWorkerAsync();
            thread2.RunWorkerAsync();
        }
        // Thread 1 writes to file (and also to console)
        private static void Thread1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                lock (DummyLock)
                {
                    Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " -  3");
                    AddLog(1);
                }
            }
        }
        // Thread 2 writes to file (and also to console)
        private static void Thread2_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                lock (DummyLock)
                {
                    Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " -  4");
                    AddLog(2);
                }
            }
        }
        private static void AddLog(int num)
        {
            string logFile = Path.Combine(Environment.CurrentDirectory, "Log.txt");
            string timestamp = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            using (FileStream fs = new FileStream(logFile, FileMode.Append,
                FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sr = new StreamWriter(fs))
                {
                    sr.WriteLine(timestamp + ": " + num);
                }
            }
        } 
