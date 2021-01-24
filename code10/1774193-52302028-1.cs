    public partial class Service1 : ServiceBase
    {
        private StreamWriter writer = File.AppendText(@"C:\temp\Log.txt");
        const int nbTreads = 30;
        BlockingCollection<string> dataItems;
        bool stopCompute = false;
        List<Thread> threads = new List<Thread>();
        Thread threadProd;
        private object aLock = new object();
        public Service1()
        {
            InitializeComponent();
            dataItems = new BlockingCollection<string>(nbTreads);
            writer.AutoFlush = true;
        }
        protected override void OnStart(string[] args)
        {
            Log("--------------");
            Log("OnStart");
            threadProd = new Thread(new ThreadStart(ProduireNomFichier));
            threadProd.Start();
            Thread.Sleep(1000); // fill the collection a little
            for (int i = 0; i < nbTreads; i++)
            {
                Thread threadRun = new Thread(() => Run());
                threadRun.Priority = ThreadPriority.Lowest;
                threadRun.Start();
                threads.Add(threadRun);
            }
        }
        private void ProduireNomFichier()
        {
            foreach (string nomFichier in Directory.EnumerateFiles(Environment.SystemDirectory))
            {
                dataItems.Add(nomFichier);
            }
        }
        protected override void OnStop()
        {
            lock (aLock)
            {
                stopCompute = true;
            }
            Log("OnStop");
            Log("--------------");
            threadProd.Abort();
        }
        private void Log(string line)
        {
            writer.WriteLine(String.Format("{0:yyyy-MM-dd HH:mm:ss.fff}: [{1,2}] {2}",
                DateTime.Now, Thread.CurrentThread.ManagedThreadId, line));
        }
        private void Run()
        {
            try
            {
                using (var sha = SHA256.Create())
                {
                    while (dataItems.TryTake(out string fileName))
                    {
                        lock (aLock)
                        {
                            if (stopCompute) return;
                        }
                        try
                        {
                            var hash = sha.ComputeHash(File.ReadAllBytes(fileName).OrderBy(x => x).ToArray());
                            Log(String.Format("file={0}, sillyhash={1}", fileName, Convert.ToBase64String(hash)));
                        }
                        catch (Exception ex)
                        {
                            Log(String.Format("file={0}, exception={1}", fileName, ex.Message));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(String.Format("exception={0}", ex.Message));
            }
        }
    }
