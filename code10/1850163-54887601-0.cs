    public partial class Service1 : ServiceBase
    {
        private Thread executeThread;
        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            try
            {
                Thread.Sleep(10000);
                executeThread = new Thread(new ThreadStart(Execute));
                executeThread.Start();
            }
            catch (Exception e)
            {
                var err = new StreamWriter("E:\\DataLogs\\Errors", true);
                err.WriteLine(DateTime.Now.ToString() + " OnStart: " + e.Message.ToString());
                err.Flush();
                err.Close();
                OnStop();
            }
        }
        protected override void OnStop()
        {
            try
            {                
                executeThread.Abort();
            }
            catch (Exception e)
            {
                var err = new StreamWriter("E:\\DataLogs\\Errors", true);
                err.WriteLine(DateTime.Now.ToString() + "OnStop exception: " + e.Message.ToString());
                err.Flush();
                err.Close();
            }
        }
        public void Execute()
        {
            try
            {
                StreamWriter sw = null;
                string FileNameAndPath = null;
                FileNameAndPath = "E:\\DataLogs\\LogFile" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                using (sw = new StreamWriter(FileNameAndPath, true))
                {
                    sw.WriteLine("TimeStamp " + "," + "col1" + "," + "col2" + "," + "col3"
                        + "," + "col4" + "," + "col5" + "," + "col6" + ","
                        + "col8" + "," + "col9" + "," + "col7" + "," + "col10");
                    sw.Flush();
                    sw.Close();
                }
                while (true)
                {
                    Library.LogData(FileNameAndPath);
                    Thread.Sleep(5000);
                }
            }
            catch (Exception e)
            {
                var err = new StreamWriter("E:\\DataLogs\\Errors", true);
                err.WriteLine(DateTime.Now.ToString() + " Execute: " + e.Message.ToString());
                err.Flush();
                err.Close();
                OnStop();
            }
        }
        public void TestInConsole(string[] args)
        {
            Console.WriteLine("Starting.....");
            this.OnStart(args);
        } 
